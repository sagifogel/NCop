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
        protected readonly IAspectPropertyMethodWeavingSettings aspectWeavingSettings = null;
        protected readonly MethodAttributes methodAttr = MA.Public | MA.Final | MA.HideBySig | MA.NewSlot | MA.Virtual;
        protected readonly CallingConventions callingConventions = CallingConventions.Standard | CallingConventions.HasThis;
        protected readonly FieldAttributes singletonFieldAttributes = FieldAttributes.Private | FieldAttributes.FamANDAssem | FieldAttributes.Static;
        protected readonly MethodAttributes ctorAttributes = MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;

        internal AbstractPropertyBindingWeaver(BindingSettings bindingSettings, IAspectPropertyMethodWeavingSettings aspectWeavingSettings, IMethodScopeWeaver methodScopeWeaver) {
            this.bindingSettings = bindingSettings;
            this.methodScopeWeaver = methodScopeWeaver;
            this.aspectWeavingSettings = aspectWeavingSettings;
        }

        public FieldInfo WeavedType { get; set; }

        public FieldInfo Weave() {
            Type bindingMethodType = null;
            var getMethod = aspectWeavingSettings.PropertyInfoContract.GetGetMethod();
            var setMethod = aspectWeavingSettings.PropertyInfoContract.GetSetMethod();

            WeaveTypeBuilder();
            WeaveConstructors();

            if (getMethod.IsNotNull()) {
                WeaveGetValueMethod();
            }

            if (setMethod.IsNotNull()) {
                WeaveSetValueMethod();
            }

            bindingMethodType = typeBuilder.CreateType();

            return WeavedType = bindingMethodType.GetField(fieldBuilder.Name, BindingFlags.NonPublic | BindingFlags.Static);
        }

        protected void WeaveTypeBuilder() {
            var declaringType = aspectWeavingSettings.PropertyInfoContract.DeclaringType;
            var types = new[] { declaringType, aspectWeavingSettings.PropertyInfoContract.PropertyType };
            var baseType = typeof(AbstractPropertyBinding<,>).MakeGenericType(types);

            typeBuilder = baseType.DefineType("PropertyBinding_{0}".Fmt(Interlocked.Increment(ref bindingCounter)).ToUniqueName(), attributes: TypeAttributes.Public | TypeAttributes.Sealed);
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

        protected virtual void WeaveGetValueMethod() {
            ILGenerator ilGenerator = null;
            MethodBuilder methodBuilder = null;
            var methodParameters = ResolveParameterTypes();
            IMethodScopeWeaver methodDecoratorScopeWeaver = null;

            methodBuilder = typeBuilder.DefineMethod("GetValue", methodAttr, callingConventions, methodParameters.ReturnType, methodParameters.Parameters);
            ilGenerator = methodBuilder.GetILGenerator();
            methodDecoratorScopeWeaver = new GetPropertyDecoratorScopeWeaver(aspectWeavingSettings);
            methodDecoratorScopeWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Ret);
        }

        protected virtual void WeaveSetValueMethod() {
            var parameters = new Type[3];
            ILGenerator ilGenerator = null;
            MethodBuilder methodBuilder = null;
            var methodParameters = ResolveParameterTypes();
            var methodDecoratorScopeWeaver = new SetPropertyDecoratorScopeWeaver(aspectWeavingSettings);

            methodParameters.Parameters.CopyTo(parameters, 0);
            parameters[parameters.Length - 1] = methodParameters.ReturnType;
            methodBuilder = typeBuilder.DefineMethod("SetValue", methodAttr, callingConventions, typeof(void), parameters);
            ilGenerator = methodBuilder.GetILGenerator();
            methodDecoratorScopeWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}
