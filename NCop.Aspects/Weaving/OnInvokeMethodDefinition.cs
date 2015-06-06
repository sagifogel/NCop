
using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;
namespace NCop.Aspects.Weaving
{
    public class OnInvokeMethodSignatureWeaver : IMethodSignatureWeaver
    {
        private readonly IAspectTypeDefinition typeDefinition = null;
        private readonly EventBrokerFieldTypeDefinition eventBrokerFieldTypeDefinition = null;
        private static readonly MethodAttributes onInvokeAttr = MethodAttributes.Public | MethodAttributes.HideBySig;

        public OnInvokeMethodSignatureWeaver(EventInfo @event, IAspectTypeDefinition typeDefinition) {
            this.typeDefinition = typeDefinition;
            eventBrokerFieldTypeDefinition = typeDefinition.GetEventBrokerFielTypeDefinition(@event);
        }

        public MethodBuilder Weave(MethodInfo methodInfo = null) {
            var invokeMethod = eventBrokerFieldTypeDefinition.OnInvokeMethodName;
            var eventInterceptionArgs = eventBrokerFieldTypeDefinition.EventInterceptionArgs;

            return typeDefinition.TypeBuilder.DefineMethod(invokeMethod, onInvokeAttr, typeof(void), new[] { eventInterceptionArgs });
        }
    }
}
