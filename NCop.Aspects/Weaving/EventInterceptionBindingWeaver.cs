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
    internal class EventInterceptionBindingWeaver : IBindingWeaver, IBindingTypeReflector
    {
        private Type baseType = null;
        protected EventInfo @event = null;
        protected static int bindingCounter = 0;
        protected TypeBuilder typeBuilder = null;
        protected FieldBuilder fieldBuilder = null;
        protected readonly BindingSettings bindingSettings = null;
        protected readonly IMethodScopeWeaver invokeMethodScopeWeaver = null;
        protected readonly IAspectWeavingSettings aspectWeavingSettings = null;
        protected readonly MethodAttributes methodAttr = MA.Public | MA.HideBySig | MA.Virtual;
        protected readonly CallingConventions callingConventions = CallingConventions.Standard | CallingConventions.HasThis;
        protected readonly FieldAttributes singletonFieldAttributes = FieldAttributes.Private | FieldAttributes.FamANDAssem | FieldAttributes.Static;
        protected readonly MethodAttributes ctorAttributes = MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;

        public EventInterceptionBindingWeaver(EventInfo @event, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IAspectWeaver invokeMethodScopeWeaver) {
            this.@event = @event;
            this.bindingSettings = bindingSettings;
            this.aspectWeavingSettings = aspectWeavingSettings;
            this.invokeMethodScopeWeaver = invokeMethodScopeWeaver;
        }

        public FieldInfo WeavedType { get; set; }

        public FieldInfo Weave() {
            WeaveTypeBuilder();
            WeaveConstructors();
            WeaveAddHandlerMethod();
            WeaveRemoveHandlerMethod();
            WeaveInvokeHandlerMethod();
            
            return WeavedType = typeBuilder.CreateType()
                                           .GetField(fieldBuilder.Name, BindingFlags.NonPublic | BindingFlags.Static);
        }

        protected void WeaveTypeBuilder() {
            var declaringType = @event.DeclaringType;
            var types = new[] { declaringType, @event.EventHandlerType };

            baseType = typeof(AbstractPropertyBinding<,>).MakeGenericType(types);
            typeBuilder = baseType.DefineType("EventBinding_{0}".Fmt(Interlocked.Increment(ref bindingCounter)).ToUniqueName(), attributes: TypeAttributes.Public | TypeAttributes.Sealed);
        }

        protected virtual void WeaveConstructors() {
            var cctor = typeBuilder.DefineConstructor(ctorAttributes | MethodAttributes.Static, CallingConventions.Standard, Type.EmptyTypes);
            var cctorILGenerator = cctor.GetILGenerator();
            var defaultCtor = typeBuilder.DefineConstructor(ctorAttributes, CallingConventions.Standard | CallingConventions.HasThis, Type.EmptyTypes);
            var bindingTypeCtor = baseType.GetConstructor(Type.EmptyTypes);
            var defaultCtorGenerator = defaultCtor.GetILGenerator();

            fieldBuilder = typeBuilder.DefineField("singleton", typeBuilder, singletonFieldAttributes);

            defaultCtorGenerator.EmitLoadArg(0);
            defaultCtorGenerator.Emit(OpCodes.Call, bindingTypeCtor);
            defaultCtorGenerator.Emit(OpCodes.Ret);

            cctorILGenerator.Emit(OpCodes.Newobj, defaultCtor);
            cctorILGenerator.Emit(OpCodes.Stsfld, fieldBuilder);
            cctorILGenerator.Emit(OpCodes.Ret);
        }

        protected virtual MethodParameters ResolveParameterTypes(bool set = false) {
            Type[] parameters = null;
            var methodParameters = bindingSettings.ToBindingMethodParameters();

            if (!set) {
                return methodParameters;
            }

            parameters = new Type[methodParameters.Parameters.Length + 1];
            methodParameters.Parameters.CopyTo(parameters, 0);
            parameters[methodParameters.Parameters.Length] = @event.EventHandlerType;
            methodParameters.Parameters = parameters;

            return methodParameters;
        }

        protected virtual void WeaveInvokeHandlerMethod() {
            ILGenerator ilGenerator = null;
            MethodBuilder methodBuilder = null;
            var methodParameters = ResolveParameterTypes();

            methodBuilder = typeBuilder.DefineMethod("InvokeHandler", methodAttr, callingConventions, methodParameters.ReturnType, methodParameters.Parameters);
            ilGenerator = methodBuilder.GetILGenerator();
            invokeMethodScopeWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Ret);
        }

        protected virtual void WeaveAddHandlerMethod() {
            ILGenerator ilGenerator = null;
            MethodBuilder methodBuilder = null;
            var methodParameters = ResolveParameterTypes();

            methodBuilder = typeBuilder.DefineMethod("AddHandler", methodAttr, callingConventions, typeof(void), methodParameters.Parameters);
            ilGenerator = methodBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ret);
        }

        protected virtual void WeaveRemoveHandlerMethod() {
            ILGenerator ilGenerator = null;
            MethodBuilder methodBuilder = null;
            var methodParameters = ResolveParameterTypes(true);

            methodBuilder = typeBuilder.DefineMethod("RemoveHandler", methodAttr, callingConventions, typeof(void), methodParameters.Parameters);
            ilGenerator = methodBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}

