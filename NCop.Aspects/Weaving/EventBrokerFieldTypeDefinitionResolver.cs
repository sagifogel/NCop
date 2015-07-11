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
            Type delegateType = null;
            var @event = memberMap.ContractMember;
            var declaringType = memberMap.ContractType;
            var invokeMethod = @event.GetInvokeMethod();
            var invokeReturnType = invokeMethod.ReturnType;
            var eventBrokerResolvedType = new EventBrokerResolvedType(@event) {
                DecalringType = declaringType
            };

            var delegateParameters = invokeMethod.GetParameters()
                                                 .Select(p => p.ParameterType)
                                                 .ToArray();

            if (invokeMethod.IsFunction()) {
                var @params = new Type[delegateParameters.Length + 1];

                if (delegateParameters.Length > 0) {
                    Array.Copy(delegateParameters, 0, @params, 0, delegateParameters.Length - 1);
                    @params[@params.Length - 1] = invokeReturnType;
                }
                else {
                    @params[0] = invokeMethod.ReturnType;
                }

                delegateType = @params.GetDelegateType(true);
                eventBrokerResolvedType.EventBrokerBaseClassType = declaringType.MakeGenericEventBrokerBaseClassFunctionBinding(@params);
                eventBrokerResolvedType.EventBrokerInvokeDelegateType = typeof(Func<,>).MakeGenericType(new[] { @event.ToEventArgumentContract(@params), invokeReturnType });
            }
            else {
                delegateType = delegateParameters.GetDelegateType(false);
                eventBrokerResolvedType.EventBrokerBaseClassType = declaringType.MakeGenericEventBrokerBaseClassActionType(delegateParameters);
                eventBrokerResolvedType.EventBrokerInvokeDelegateType = typeof(Action<>).MakeGenericType(new[] { @event.ToEventArgumentContract(delegateParameters) });
            }
            
            eventBrokerResolvedType.Arguments = delegateParameters;
            eventBrokerResolvedType.EventBrokerFieldType = typeof(IEventBroker<>).MakeGenericType(delegateType);

            return eventBrokerResolvedType;
        }

        public static Type ToEventBrokerType(this EventInfo @event) {
            Type delegateType = null;
            var addMethod = @event.GetAddMethod();
            var firstParameter = addMethod.GetParameters()[0].ParameterType;
            var invokeMethod = firstParameter.GetMethod("Invoke");
            var delegateParameters = invokeMethod.GetParameters()
                                                 .Select(p => p.ParameterType)
                                                 .ToArray();

            if (invokeMethod.IsFunction()) {
                var @params = new Type[delegateParameters.Length + 1];

                if (delegateParameters.Length > 0) {
                    Array.Copy(delegateParameters, 0, @params, 0, delegateParameters.Length - 1);
                    @params[@params.Length - 1] = invokeMethod.ReturnType;
                }
                else {
                    @params[0] = invokeMethod.ReturnType;
                }

                delegateType = @params.GetDelegateType(true);
            }
            else {
                delegateType = delegateParameters.GetDelegateType(false);
            }

            return typeof(IEventBroker<>).MakeGenericType(delegateType);
        }
    }
}
