using System.Reflection;
using System.Reflection.Emit;
using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
    public class RaiseEventMethodSignatureWeaver : AbstractEventSignatureWeaver
    {
        private readonly EventBrokerFieldTypeDefinition eventBrokerFieldTypeDefinition = null;

        public RaiseEventMethodSignatureWeaver(IEventTypeBuilder eventTypeBuilder, ITypeDefinition typeDefinition, EventBrokerFieldTypeDefinition eventBrokerFieldTypeDefinition)
            : base(eventTypeBuilder, typeDefinition) {
            this.eventBrokerFieldTypeDefinition = eventBrokerFieldTypeDefinition;
        }

        public override MethodBuilder Weave(MethodInfo method) {
            var methodBuilder = typeDefinition.TypeBuilder.DefineMethod(eventBrokerFieldTypeDefinition.InvokeMethodName, MethodAttributes.Public | MethodAttributes.HideBySig, method.ReturnType, new[] { eventBrokerFieldTypeDefinition.EventInterceptionContractArgs });

            eventTypeBuilder.SetRaiseMethod(methodBuilder);

            return eventBrokerFieldTypeDefinition.InvokeMethodBuilder = methodBuilder;
        }
    }
}