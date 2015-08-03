using NCop.Core;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using MA = System.Reflection.MethodAttributes;

namespace NCop.Aspects.Weaving
{
    public class EventBrokerWeaver : IWeaver
    {
        private MethodBuilder interceptMethod = null;
        private readonly TypeBuilder typeBuilder = null;
        private readonly IEnumerable<IEventMap> eventMaps = null;
        private static readonly MA interceptMethodAttrs = MA.Private | MA.HideBySig;
        private static readonly MA subscribtionsMethodsAttrs = MA.Family | MA.HideBySig | MA.Virtual;
        private static readonly MA ctorAttrs = MA.Public | MA.SpecialName | MA.HideBySig | MA.RTSpecialName;
        private readonly List<EventBrokerFieldTypeDefinition> eventTypeDefinitions = new List<EventBrokerFieldTypeDefinition>();

        public EventBrokerWeaver(TypeBuilder typeBuilder, IEnumerable<IEventMap> eventMaps) {
            this.typeBuilder = typeBuilder;
            this.eventMaps = eventMaps;
        }

        private Type WeaveEventBrokerType(EventBrokerResolvedType eventBrokerResolvedType) {
            var eventBrokerTypeBuilder = eventBrokerResolvedType.EventBrokerBaseClassType.DefineType(attributes: TypeAttributes.Public | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit);

            WeaveConstructor(eventBrokerTypeBuilder, eventBrokerResolvedType);
            interceptMethod = WeaveInterceptMethod(eventBrokerTypeBuilder, eventBrokerResolvedType);
            WeaveSubscribeImpl(eventBrokerTypeBuilder, eventBrokerResolvedType);
            WeaveUnsubscribeImpl(eventBrokerTypeBuilder, eventBrokerResolvedType);

            return eventBrokerTypeBuilder.CreateType();
        }

        private void WeaveConstructor(TypeBuilder typeBuilder, EventBrokerResolvedType eventBrokerResolvedType) {
            ConstructorBuilder ctor = null;
            ILGenerator ilGenerator = null;
            var ctorArgs = new[] { eventBrokerResolvedType.DecalringType, eventBrokerResolvedType.EventBrokerInvokeDelegateType };
            var baseCtor = eventBrokerResolvedType.EventBrokerBaseClassType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, Type.DefaultBinder, ctorArgs, null);

            ctor = typeBuilder.DefineConstructor(ctorAttrs, CallingConventions.Standard | CallingConventions.HasThis, ctorArgs);
            ilGenerator = ctor.GetILGenerator();
            ilGenerator.EmitLoadArg(0);
            ctorArgs.ForEach(1, (arg, i) => ilGenerator.EmitLoadArg(i));
            ilGenerator.Emit(OpCodes.Call, baseCtor);
            ilGenerator.Emit(OpCodes.Ret);
        }

        private MethodBuilder WeaveInterceptMethod(TypeBuilder typeBuilder, EventBrokerResolvedType eventBrokerResolvedType) {
            var interceptMethod = typeBuilder.DefineMethod("Intercept", interceptMethodAttrs, eventBrokerResolvedType.EventBrokerInvokeDelegateType, eventBrokerResolvedType.Arguments);
            var ilGenerator = interceptMethod.GetILGenerator();
            var onEventFiredMethod = eventBrokerResolvedType.EventBrokerBaseClassType.GetMethod("OnEventFired", BindingFlags.NonPublic | BindingFlags.Instance);

            ilGenerator.EmitLoadArg(0);
            eventBrokerResolvedType.Arguments.ForEach(1, (arg, i) => ilGenerator.EmitLoadArg(i));
            ilGenerator.Emit(OpCodes.Call, onEventFiredMethod);
            ilGenerator.Emit(OpCodes.Ret);

            return interceptMethod;
        }

        private void WeaveSubscribeImpl(TypeBuilder typeBuilder, EventBrokerResolvedType eventBrokerResolvedType) {
            WeaveSubscriptionMethod(typeBuilder, eventBrokerResolvedType, eventBrokerResolvedType.Event.GetAddMethod(), "SubscribeImpl");
        }

        private void WeaveUnsubscribeImpl(TypeBuilder typeBuilder, EventBrokerResolvedType eventBrokerResolvedType) {
            WeaveSubscriptionMethod(typeBuilder, eventBrokerResolvedType, eventBrokerResolvedType.Event.GetRemoveMethod(), "UnsubscribeImpl");
        }

        private void WeaveSubscriptionMethod(TypeBuilder typeBuilder, EventBrokerResolvedType eventBrokerResolvedType, MethodInfo eventHandlerMethod, string methodName) {
            var instanceField = eventBrokerResolvedType.EventBrokerBaseClassType.GetField("instance", BindingFlags.NonPublic | BindingFlags.Instance);
            var subscribeImplMethod = typeBuilder.DefineMethod(methodName, subscribtionsMethodsAttrs, typeof(void), eventBrokerResolvedType.Arguments);
            var eventHanlderCtor = eventBrokerResolvedType.Event.EventHandlerType.GetConstructor(new[] { typeof(object), typeof(IntPtr) });
            var ilGenerator = subscribeImplMethod.GetILGenerator();

            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, instanceField);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldftn, interceptMethod);
            ilGenerator.Emit(OpCodes.Newobj, eventHanlderCtor);
            ilGenerator.Emit(OpCodes.Callvirt, eventHandlerMethod);
            ilGenerator.Emit(OpCodes.Ret);
        }

        public IEnumerable<EventBrokerFieldTypeDefinition> Weave() {
            eventMaps.ForEach(eventMap => {
                var @event = eventMap.ContractMember;
                var eventBrokerResolvedType = EventBrokerFieldTypeDefinitionResolver.ResolveType(eventMap, typeBuilder);
                var eventBrokerGeneratedType = WeaveEventBrokerType(eventBrokerResolvedType);

                eventTypeDefinitions.Add(new EventBrokerFieldTypeDefinition(@event, eventBrokerResolvedType, typeBuilder, eventBrokerGeneratedType));
            });

            return eventTypeDefinitions;
        }
    }
}
