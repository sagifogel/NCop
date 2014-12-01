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
    internal abstract class AbstractPropertyBindingWeaver : IMethodBindingWeaver, IBindingTypeReflector
    {
        protected static int bindingCounter = 0;
        protected TypeBuilder typeBuilder = null;
        protected FieldBuilder fieldBuilder = null;
        protected readonly BindingSettings bindingSettings = null;
        protected readonly IMethodScopeWeaver methodScopeWeaver = null;
        protected readonly IAspectMethodWeavingSettings aspectWeavingSettings = null;
        protected readonly MethodAttributes methodAttr = MA.Public | MA.Final | MA.HideBySig | MA.NewSlot | MA.Virtual;
        protected readonly CallingConventions callingConventions = CallingConventions.Standard | CallingConventions.HasThis;

        internal AbstractPropertyBindingWeaver(BindingSettings bindingSettings, IAspectMethodWeavingSettings aspectWeavingSettings, IMethodScopeWeaver methodScopeWeaver) {
            this.bindingSettings = bindingSettings;
            this.methodScopeWeaver = methodScopeWeaver;
            this.aspectWeavingSettings = aspectWeavingSettings;
        }

        public FieldInfo WeavedType { get; set; }

        public FieldInfo Weave() {
            Type bindingMethodType = null;
            var typeBuilder = WeaveTypeBuilder();

            WeaveConstructors(typeBuilder);
            WeaveGetValueMethod();
            WeaveSetValueMethod();
            bindingMethodType = typeBuilder.CreateType();

            return WeavedType = bindingMethodType.GetField(fieldBuilder.Name, BindingFlags.NonPublic | BindingFlags.Static);
        }

        protected TypeBuilder WeaveTypeBuilder() {
            return typeBuilder = typeof(object).DefineType("PropertyBinding_{0}".Fmt(Interlocked.Increment(ref bindingCounter)).ToUniqueName(), new[] { bindingSettings.BindingType }, TypeAttributes.Public | TypeAttributes.Sealed);
        }

        protected virtual void WeaveConstructors(TypeBuilder typeBuilder) {
            var fieldAttrs = FieldAttributes.Private | FieldAttributes.FamANDAssem | FieldAttributes.Static;
            var ctorAttrs = MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;
            var cctor = typeBuilder.DefineConstructor(ctorAttrs | MethodAttributes.Static, CallingConventions.Standard, Type.EmptyTypes);
            var cctorILGenerator = cctor.GetILGenerator();
            var defaultCtor = typeBuilder.DefineConstructor(ctorAttrs, CallingConventions.Standard | CallingConventions.HasThis, Type.EmptyTypes);
            var bindingTypeCtor = typeof(object).GetConstructor(Type.EmptyTypes);
            var defaultCtorGenerator = defaultCtor.GetILGenerator();

            fieldBuilder = typeBuilder.DefineField("singleton", typeBuilder, fieldAttrs);

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

        protected virtual void WeaveGetValueMethod() {
            ILGenerator ilGenerator = null;
            MethodBuilder methodBuilder = null;
            var methodParameters = ResolveParameterTypes();
            IMethodScopeWeaver methodDecoratorScopeWeaver = null;

            methodBuilder = typeBuilder.DefineMethod("GetValue", methodAttr, callingConventions, methodParameters.ReturnType, methodParameters.Parameters);
            ilGenerator = methodBuilder.GetILGenerator();
            methodDecoratorScopeWeaver = new MethodDecoratorScopeWeaver(aspectWeavingSettings);
            methodDecoratorScopeWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Ret);
        }

        protected virtual void WeaveSetValueMethod() {
            ILGenerator ilGenerator = null;
            MethodBuilder methodBuilder = null;
            var methodParameters = ResolveParameterTypes();

            methodBuilder = typeBuilder.DefineMethod("SetValue", methodAttr, callingConventions, methodParameters.ReturnType, methodParameters.Parameters);
            ilGenerator = methodBuilder.GetILGenerator();
            methodScopeWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}
