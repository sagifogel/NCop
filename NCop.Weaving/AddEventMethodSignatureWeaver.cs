using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class AddEventMethodSignatureWeaver : AbstractEventSignatureWeaver
    {
        public AddEventMethodSignatureWeaver(IEventTypeBuilder eventTypeBuilder, ITypeDefinition typeDefinition)
            : base(eventTypeBuilder, typeDefinition) {
        }

        public override MethodBuilder Weave(MethodInfo method) {
            var methodSignatureWeaver = new MethodSignatureWeaver(typeDefinition);
            var methodBuilder = methodSignatureWeaver.Weave(method);

            eventTypeBuilder.SetAddMethod(methodBuilder);

            return methodBuilder;
        }
    }
}