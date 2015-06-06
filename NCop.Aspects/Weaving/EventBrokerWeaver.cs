using NCop.Aspects.Engine;
using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using NCop.Weaving.Extensions;
using FA = System.Reflection.FieldAttributes;
using MA = System.Reflection.MethodAttributes;

namespace NCop.Aspects.Weaving
{
    public class EventBrokerWeaver : IWeaver
    {
        private MethodBuilder interceptMethod = null;
        private FieldBuilder onInvokeFieldBuilder = null;
        private static readonly MA interceptMethodAttrs = MA.Private | MA.HideBySig;
        private static readonly FA onInvokeFieldBuilderAttrs = FA.Private | FA.InitOnly;
        private static readonly MA subscribtionsMethodsAttrs = MA.Family | MA.HideBySig | MA.Virtual;
        private static readonly MA ctorAttrs = MA.Public | MA.SpecialName | MA.HideBySig | MA.RTSpecialName;
        private readonly List<EventBrokerFieldTypeDefinition> eventTypeDefinitions = new List<EventBrokerFieldTypeDefinition>();

        public EventBrokerWeaver(TypeBuilder typeBuilder, IEnumerable<IAspectEvent> aspectEvents) {
            aspectEvents.ForEach(aspectEvent => {
                var @event = aspectEvent.ContractMember;
                var eventBrokerResolvedType = EventBrokerFieldTypeDefinitionResolver.ResolveType(aspectEvent, typeBuilder);
                var eventBrokerGeneratedType = WeaveEventBrokerType(aspectEvent, eventBrokerResolvedType);

                eventTypeDefinitions.Add(new EventBrokerFieldTypeDefinition(@event, eventBrokerResolvedType.EventBrokerFieldType, typeBuilder, eventBrokerGeneratedType, eventBrokerResolvedType.OnInvokeUniqueName, eventBrokerResolvedType.EventInterceptionArgs));
            });
        }

        private Type WeaveEventBrokerType(IAspectEvent aspectEvent, EventBrokerResolvedType eventBrokerResolvedType) {
            var @event = aspectEvent.ContractMember;
            var eventBrokerTypeBuilder = eventBrokerResolvedType.EventBrokerBaseClassType.DefineType();

            onInvokeFieldBuilder = WeaveDelegateField(eventBrokerTypeBuilder, eventBrokerResolvedType);
            WeaveConstructor(eventBrokerTypeBuilder, eventBrokerResolvedType, onInvokeFieldBuilder);
            interceptMethod = WeaveInterceptMethod(eventBrokerTypeBuilder, eventBrokerResolvedType);
            WeaveSubscribeImpl(eventBrokerTypeBuilder, eventBrokerResolvedType);
            WeaveUnsubscribeImpl(eventBrokerTypeBuilder, eventBrokerResolvedType);
            WeaveOnInvokeHandler(aspectEvent, eventBrokerTypeBuilder, eventBrokerResolvedType, onInvokeFieldBuilder);

            return eventBrokerTypeBuilder.CreateType();
        }

        private FieldBuilder WeaveDelegateField(TypeBuilder typeBuilder, EventBrokerResolvedType eventBrokerResolvedType) {
            var eventArgsActionImpl = typeof(Action<>).MakeGenericType(eventBrokerResolvedType.EventInterceptionArgs);

            return typeBuilder.DefineField("onInvokeHandler", eventArgsActionImpl, onInvokeFieldBuilderAttrs);
        }

        private void WeaveConstructor(TypeBuilder typeBuilder, EventBrokerResolvedType eventBrokerResolvedType, FieldBuilder onInvokeFieldBuilder) {
            ConstructorBuilder ctor = null;
            ILGenerator ilGenerator = null;
            var ctorArgs = new Type[] { eventBrokerResolvedType.DecalringType, eventBrokerResolvedType.EventBrokerBindingType, onInvokeFieldBuilder.FieldType };

            ctor = typeBuilder.DefineConstructor(ctorAttrs, CallingConventions.Standard | CallingConventions.HasThis, ctorArgs);
            ilGenerator = ctor.GetILGenerator();
            ilGenerator.EmitLoadArg(0);
            ilGenerator.EmitLoadArg(1);
            ilGenerator.EmitLoadArg(2);
            ilGenerator.Emit(OpCodes.Call, eventBrokerResolvedType.EventBrokerBaseClassType);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.EmitLoadArg(3);
            ilGenerator.Emit(OpCodes.Stfld, onInvokeFieldBuilder);
            ilGenerator.Emit(OpCodes.Ret);
        }

        private MethodBuilder WeaveInterceptMethod(TypeBuilder typeBuilder, EventBrokerResolvedType eventBrokerResolvedType) {
            var interceptMethod = typeBuilder.DefineMethod("Intercept", interceptMethodAttrs, typeof(void), eventBrokerResolvedType.Arguments);
            var ilGenerator = interceptMethod.GetILGenerator();
            var onEventFiredMethod = eventBrokerResolvedType.EventBrokerBaseClassType.GetMethod("OnEventFired", BindingFlags.NonPublic | BindingFlags.Instance);

            ilGenerator.EmitLoadArg(0);

            eventBrokerResolvedType.Arguments.ForEach(1, (arg, i) => {
                ilGenerator.EmitLoadArg(i);
            });

            ilGenerator.Emit(OpCodes.Call, onEventFiredMethod);
            ilGenerator.Emit(OpCodes.Ret);

            return interceptMethod;
        }

        private void WeaveSubscribeImpl(TypeBuilder typeBuilder, EventBrokerResolvedType eventBrokerResolvedType) {
            WeaveSubscribitionMethod(typeBuilder, eventBrokerResolvedType, eventBrokerResolvedType.Event.GetAddMethod(), "SubscribeImpl");
        }

        private void WeaveUnsubscribeImpl(TypeBuilder typeBuilder, EventBrokerResolvedType eventBrokerResolvedType) {
            WeaveSubscribitionMethod(typeBuilder, eventBrokerResolvedType, eventBrokerResolvedType.Event.GetRemoveMethod(), "UnsubscribeImpl");
        }

        private void WeaveOnInvokeHandler(IAspectEvent aspectEvent, TypeBuilder typeBuilder, EventBrokerResolvedType eventBrokerResolvedType, FieldBuilder onInvokeFieldBuilder) {
            var interceptMethod = typeBuilder.DefineMethod("OnInvokeHandler", subscribtionsMethodsAttrs, typeof(void), new Type[] { eventBrokerResolvedType.EventInterceptionArgs });
            var ilGenerator = interceptMethod.GetILGenerator();

            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, onInvokeFieldBuilder);
            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Callvirt, onInvokeFieldBuilder.FieldType);
            ilGenerator.Emit(OpCodes.Ret);
        }

        private void WeaveSubscribitionMethod(TypeBuilder typeBuilder, EventBrokerResolvedType eventBrokerResolvedType, MethodInfo eventHandlerMethod, string methodName) {
            var eventHandlerType = eventBrokerResolvedType.Event.EventHandlerType;
            var instanceField = eventBrokerResolvedType.EventBrokerBaseClassType.GetField("instance", BindingFlags.NonPublic | BindingFlags.Instance);
            var subscribeImplMethod = typeBuilder.DefineMethod(methodName, subscribtionsMethodsAttrs, typeof(void), eventBrokerResolvedType.Arguments);
            var ilGenerator = subscribeImplMethod.GetILGenerator();

            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, instanceField);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldftn, interceptMethod);
            ilGenerator.Emit(OpCodes.Newobj, eventBrokerResolvedType.Event.EventHandlerType);
            ilGenerator.Emit(OpCodes.Callvirt, eventHandlerMethod);
            ilGenerator.Emit(OpCodes.Ret);
        }

        public IEnumerable<EventBrokerFieldTypeDefinition> Weave() {
            return eventTypeDefinitions;
        }
    }
}
