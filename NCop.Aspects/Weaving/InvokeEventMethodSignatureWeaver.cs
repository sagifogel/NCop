using System.Reflection;
using System.Reflection.Emit;
using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
    public class InvokeEventMethodSignatureWeaver : AbstractMemberSignatureWeaver
    {
        private EventBrokerFieldTypeDefinition eventBrokerFieldTypeDefinition = null;

        public InvokeEventMethodSignatureWeaver(ITypeDefinition typeDefinition, EventBrokerFieldTypeDefinition eventBrokerFieldTypeDefinition)
            : base(typeDefinition) {
            this.eventBrokerFieldTypeDefinition = eventBrokerFieldTypeDefinition;
        }

        public override MethodBuilder Weave(MethodInfo method) {
            return typeDefinition.TypeBuilder.DefineMethod(eventBrokerFieldTypeDefinition.InvokeMethodName, MethodAttributes.Private | MethodAttributes.HideBySig, method.ReturnType, new[] { eventBrokerFieldTypeDefinition.EventInterceptionContractArgs });
        }
    }
}