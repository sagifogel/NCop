using NCop.Aspects.Engine;
using NCop.Aspects.Extensions;
using NCop.Core;
using NCop.Core.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public static class EventBrokerFieldTypeDefinitionResolver
    {
        public static EventBrokerResolvedType ResolveType(IMemberMap<EventInfo> memberMap, TypeBuilder typeBuilder) {
            Type[] @params = null;
            Type delegateType = null;
            Type[] delegateParameters = null;
            var @event = memberMap.ContractMember;
            var declaringType = memberMap.ContractType;
            var invokeMethod = @event.GetInvokeMethod();
            var invokeReturnType = invokeMethod.ReturnType;
            var eventBrokerResolvedType = new EventBrokerResolvedType(@event) {
                DecalringType = declaringType
            };

            if (invokeMethod.GetDelegateParams(out @params, out delegateParameters)) {
                delegateType = @params.GetDelegateType(true);
                eventBrokerResolvedType.EventInterceptionContractArgs = @event.ToEventArgumentContract(@params);
                eventBrokerResolvedType.EventInterceptionArgs = declaringType.MakeGenericFunctionAspectArgsEvent(@params);
                eventBrokerResolvedType.EventBrokerBaseClassType = declaringType.MakeGenericEventBrokerBaseClassFunctionBinding(@params);
                eventBrokerResolvedType.EventBrokerInvokeDelegateType = typeof(Func<,>).MakeGenericType(new[] { eventBrokerResolvedType.EventInterceptionContractArgs, invokeReturnType });
            }
            else {
                delegateType = delegateParameters.GetDelegateType(false);
                eventBrokerResolvedType.EventInterceptionContractArgs = @event.ToEventArgumentContract(delegateParameters);
                eventBrokerResolvedType.EventInterceptionArgs = declaringType.MakeGenericActionAspectArgsEvent(delegateParameters);
                eventBrokerResolvedType.EventBrokerBaseClassType = declaringType.MakeGenericEventBrokerBaseClassActionType(delegateParameters);
                eventBrokerResolvedType.EventBrokerInvokeDelegateType = typeof(Action<>).MakeGenericType(new[] { eventBrokerResolvedType.EventInterceptionContractArgs });
            }

            eventBrokerResolvedType.Arguments = delegateParameters;
            eventBrokerResolvedType.EventBrokerFieldType = typeof(IEventBroker<>).MakeGenericType(delegateType);

            return eventBrokerResolvedType;
        }

        public static Type ToEventBrokerType(this EventInfo @event) {
            Type[] @params;
            Type[] delegateParameters;
            Type delegateType = null;
            var addMethod = @event.GetAddMethod();
            var firstParameter = addMethod.GetParameters()[0].ParameterType;
            var invokeMethod = firstParameter.GetMethod("Invoke");

            if (invokeMethod.GetDelegateParams(out @params, out delegateParameters)) {
                delegateType = @params.GetDelegateType(true);
            }
            else {
                delegateType = delegateParameters.GetDelegateType(false);
            }

            return typeof(IEventBroker<>).MakeGenericType(delegateType);
        }
    }
}
