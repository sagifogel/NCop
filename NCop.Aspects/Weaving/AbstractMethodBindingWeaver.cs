using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using MA = System.Reflection.MethodAttributes;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractMethodBindingWeaver : IBindingWeaver, IBindingTypeReflector
    {
        protected static int bindingCounter = 0;
        protected TypeBuilder typeBuilder = null;
        protected FieldBuilder fieldBuilder = null;
        private readonly MethodInfo methodInfo = null;
        protected readonly BindingSettings bindingSettings = null;
        protected readonly IMethodScopeWeaver methodScopeWeaver = null;
        protected readonly IAspectWeavingSettings aspectWeavingSettings = null;
        protected readonly MethodAttributes methodAttr = MA.Public | MA.Final | MA.HideBySig | MA.NewSlot | MA.Virtual;
        protected readonly MethodAttributes ctorAttributes = MA.Private | MA.HideBySig | MA.SpecialName | MA.RTSpecialName;
        protected readonly CallingConventions callingConventions = CallingConventions.Standard | CallingConventions.HasThis;
        protected readonly FieldAttributes singletonFieldAttributes = FieldAttributes.Private | FieldAttributes.FamANDAssem | FieldAttributes.Static;

        internal AbstractMethodBindingWeaver(MethodInfo methodInfo, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IMethodScopeWeaver methodScopeWeaver) {
            this.methodInfo = methodInfo;
            this.bindingSettings = bindingSettings;
            this.methodScopeWeaver = methodScopeWeaver;
            this.aspectWeavingSettings = aspectWeavingSettings;
        }

        public FieldInfo WeavedType { get; set; }

        public FieldInfo Weave() {
            WeaveTypeBuilder();
            WeaveConstructors();
            WeaveInvokeMethod();
            WeaveProceedMethod();

            return WeavedType = typeBuilder.CreateType()
                                           .GetField(fieldBuilder.Name, BindingFlags.NonPublic | BindingFlags.Static);
        }

        protected void WeaveTypeBuilder() {
            typeBuilder = typeof(object).DefineType("MethodBinding_{0}".Fmt(Interlocked.Increment(ref bindingCounter)).ToUniqueName(), new[] { bindingSettings.BindingType }, TypeAttributes.Public | TypeAttributes.Sealed);
        }

        protected virtual void WeaveConstructors() {
            var cctor = typeBuilder.DefineConstructor(ctorAttributes | MethodAttributes.Static, CallingConventions.Standard, Type.EmptyTypes);
            var cctorILGenerator = cctor.GetILGenerator();
            var defaultCtor = typeBuilder.DefineConstructor(ctorAttributes, CallingConventions.Standard | CallingConventions.HasThis, Type.EmptyTypes);
            var bindingTypeCtor = typeof(object).GetConstructor(Type.EmptyTypes);
            var defaultCtorGenerator = defaultCtor.GetILGenerator();

            fieldBuilder = typeBuilder.DefineField("singleton", typeBuilder, singletonFieldAttributes);

            defaultCtorGenerator.EmitLoadArg(0);
            defaultCtorGenerator.Emit(OpCodes.Call, bindingTypeCtor);
            defaultCtorGenerator.Emit(OpCodes.Ret);

            cctorILGenerator.Emit(OpCodes.Newobj, defaultCtor);
            cctorILGenerator.Emit(OpCodes.Stsfld, fieldBuilder);
            cctorILGenerator.Emit(OpCodes.Ret);
        }

        protected virtual MethodParameters ResolveParameterTypes() {
            return bindingSettings.ToBindingMethodParameters();
        }

        protected virtual void WeaveInvokeMethod() {
            ILGenerator ilGenerator = null;
            MethodBuilder methodBuilder = null;
            var methodParameters = ResolveParameterTypes();
            IMethodScopeWeaver methodDecoratorScopeWeaver = null;

            methodBuilder = typeBuilder.DefineMethod("Invoke", methodAttr, callingConventions, methodParameters.ReturnType, methodParameters.Parameters);
            ilGenerator = methodBuilder.GetILGenerator();
            methodDecoratorScopeWeaver = new MethodDecoratorScopeWeaver(methodInfo, aspectWeavingSettings);
            methodDecoratorScopeWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Ret);
        }

        protected virtual void WeaveProceedMethod() {
            ILGenerator ilGenerator = null;
            MethodBuilder methodBuilder = null;
            var methodParameters = ResolveParameterTypes();

            methodBuilder = typeBuilder.DefineMethod("Proceed", methodAttr, callingConventions, methodParameters.ReturnType, methodParameters.Parameters);
            ilGenerator = methodBuilder.GetILGenerator();
            methodScopeWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}
