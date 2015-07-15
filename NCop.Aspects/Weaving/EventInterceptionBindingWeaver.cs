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
        private MethodParameters methodParameters = null;
        protected readonly BindingSettings bindingSettings = null;
        protected readonly IMethodScopeWeaver addMethodScopeWeaver = null;
        protected readonly IMethodScopeWeaver removeMethodScopeWeaver = null;
        protected readonly IMethodScopeWeaver invokeMethodScopeWeaver = null;
        protected readonly IAspectWeavingSettings aspectWeavingSettings = null;
        protected readonly MethodAttributes methodAttr = MA.Public | MA.HideBySig | MA.Virtual;
        protected readonly CallingConventions callingConventions = CallingConventions.Standard | CallingConventions.HasThis;
        protected readonly FieldAttributes singletonFieldAttributes = FieldAttributes.Private | FieldAttributes.FamANDAssem | FieldAttributes.Static;
        protected readonly MethodAttributes ctorAttributes = MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;

        public EventInterceptionBindingWeaver(EventInfo @event, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IAspectWeaver addMethodScopeWeaver, IAspectWeaver removeMethodScopeWeaver, IAspectWeaver invokeMethodScopeWeaver) {
            this.@event = @event;
            this.bindingSettings = bindingSettings;
            this.addMethodScopeWeaver = addMethodScopeWeaver;
            this.aspectWeavingSettings = aspectWeavingSettings;
            this.removeMethodScopeWeaver = removeMethodScopeWeaver;
            this.invokeMethodScopeWeaver = invokeMethodScopeWeaver;
            ResolveParameterTypes();
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
            var implementationTypes = new[] { bindingSettings.BindingType };

            baseType = typeof(object);
            typeBuilder = baseType.DefineType("EventBinding_{0}".Fmt(Interlocked.Increment(ref bindingCounter)).ToUniqueName(), implementationTypes, TypeAttributes.Public | TypeAttributes.Sealed);
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

        protected void ResolveParameterTypes(bool set = false) {
            Type[] parameters = null;

            methodParameters = bindingSettings.ToBindingMethodParameters();

            if (!set) {
                return;
            }

            parameters = new Type[methodParameters.Parameters.Length + 1];
            methodParameters.Parameters.CopyTo(parameters, 0);
            parameters[methodParameters.Parameters.Length] = @event.EventHandlerType;
            methodParameters.Parameters = parameters;
        }

        protected virtual void WeaveInvokeHandlerMethod() {
            WeaveHandlerMethod("InvokeHandler", invokeMethodScopeWeaver, methodParameters.ReturnType);
        }

        protected virtual void WeaveAddHandlerMethod() {
            WeaveHandlerMethod("AddHandler", addMethodScopeWeaver, typeof(void));
        }

        protected virtual void WeaveRemoveHandlerMethod() {
            WeaveHandlerMethod("RemoveHandler", removeMethodScopeWeaver, typeof(void));
        }

        protected virtual void WeaveHandlerMethod(string methodName, IMethodScopeWeaver methodScopeWeaver, Type returnType) {
            var methodBuilder = typeBuilder.DefineMethod(methodName, methodAttr, callingConventions, returnType, methodParameters.Parameters);
            var ilGenerator = methodBuilder.GetILGenerator();

            methodScopeWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}

