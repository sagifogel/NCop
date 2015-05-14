using System;
using System.Linq;
using NCop.Aspects.Engine;
using NCop.Core.Extensions;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Linq.Expressions;

namespace NCop.Aspects.Weaving
{
    public static class EventBrokerFieldTypeDefinitionsResolver
    {
        public static bool TryResolve(Type type, TypeBuilder typeBuilder, out IEnumerable<EventBrokerFieldTypeDefinition> eventBrokerFieldTypeDefinitions) {
            var eventBrokerFieldTypeDefinitionsList = new List<EventBrokerFieldTypeDefinition>();
            var events = type.GetEvents();

            events.ForEach(@event => {
                Type delegateType = null;
                Type eventBrokerType = null;
                var addMethod = @event.GetAddMethod();
                var firstParameter = addMethod.GetParameters()[0].ParameterType;
                var invokeMethod = firstParameter.GetMethod("Invoke");
                var genericParameters = firstParameter.GetGenericArguments();

                if (invokeMethod.HasReturnType()) {
                    var @params = new Type[genericParameters.Length];

                    Array.Copy(genericParameters, 0, @params, 0, genericParameters.Length - 1);
                    @params[@params.Length - 1] = invokeMethod.ReturnType;
                    delegateType = Expression.GetFuncType(@params);
                }
                else {
                    delegateType = Expression.GetActionType(genericParameters);
                }

                eventBrokerType = typeof(IEventBroker<>).MakeGenericType(delegateType);
                eventBrokerFieldTypeDefinitionsList.Add(new EventBrokerFieldTypeDefinition(@event, eventBrokerType, typeBuilder));
            });

            eventBrokerFieldTypeDefinitions = eventBrokerFieldTypeDefinitionsList;

            return eventBrokerFieldTypeDefinitionsList.Count > 0;
        }
    }
}
