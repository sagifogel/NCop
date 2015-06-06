using NCop.Aspects.Engine;
using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public static class EventBrokerFieldTypeDefinitionResolver
    {
        public static EventBrokerResolvedType ResolveType(IAspectEvent aspectEvent, TypeBuilder typeBuilder) {
            Type delegateType = null;
            Type eventInterceptionArgs = null;
            var @event = aspectEvent.ContractMember;
            var declaringType = aspectEvent.ContractType;
            var addMethod = @event.GetAddMethod();
            var firstParameter = addMethod.GetParameters()[0].ParameterType;
            var invokeMethod = firstParameter.GetMethod("Invoke");
            var eventBrokerResolvedType = new EventBrokerResolvedType(@event) {
                DecalringType = declaringType,
                OnInvokeUniqueName = "OnInvoke<{0}>".Fmt(Guid.NewGuid())
            };

            var delegateParameters = invokeMethod.GetParameters()
                                                 .Select(p => p.ParameterType)
                                                 .ToArray();

            if (invokeMethod.HasReturnType()) {
                var @params = new Type[delegateParameters.Length + 1];

                if (delegateParameters.Length > 0) {
                    Array.Copy(delegateParameters, 0, @params, 0, delegateParameters.Length - 1);
                    @params[@params.Length - 1] = invokeMethod.ReturnType;
                }
                else {
                    @params[0] = invokeMethod.ReturnType;
                }

                eventBrokerResolvedType.Arguments = @params;
                delegateType = Expression.GetFuncType(@params);
                eventInterceptionArgs = eventBrokerResolvedType.EventInterceptionArgs = declaringType.MakeGenericFunctionAspectArgsEvent(@params);
                eventBrokerResolvedType.EventBrokerBindingType = eventInterceptionArgs.BaseType.MakeEventGenericFunctionBinding(eventInterceptionArgs.GetGenericArguments());
                eventBrokerResolvedType.EventBrokerBaseClassType = declaringType.MakeGenericEventBrokerBaseClassFunctionBinding(@params);
            }
            else {
                eventBrokerResolvedType.Arguments = delegateParameters;
                eventInterceptionArgs = eventBrokerResolvedType.EventInterceptionArgs = declaringType.MakeGenericActionAspectArgsEvent(delegateParameters);
                eventBrokerResolvedType.EventBrokerBaseClassType = declaringType.MakeGenericEventBrokerBaseClassActionType(delegateParameters);
                delegateType = Expression.GetActionType(delegateParameters);
                eventBrokerResolvedType.EventBrokerBindingType = eventInterceptionArgs.BaseType.MakeEventGenericActionBinding(eventInterceptionArgs.GetGenericArguments());
            }

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

            if (invokeMethod.HasReturnType()) {
                var @params = new Type[delegateParameters.Length + 1];

                if (delegateParameters.Length > 0) {
                    Array.Copy(delegateParameters, 0, @params, 0, delegateParameters.Length - 1);
                    @params[@params.Length - 1] = invokeMethod.ReturnType;
                }
                else {
                    @params[0] = invokeMethod.ReturnType;
                }

                delegateType = Expression.GetFuncType(@params);
            }
            else {
                delegateType = Expression.GetActionType(delegateParameters);
            }

            return typeof(IEventBroker<>).MakeGenericType(delegateType);
        }
    }
}
