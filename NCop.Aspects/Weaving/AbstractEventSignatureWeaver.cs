using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
    public abstract class AbstractEventSignatureWeaver : AbstractMemberSignatureWeaver
    {
        protected readonly IEventTypeBuilder eventTypeBuilder = null;

        protected AbstractEventSignatureWeaver(IEventTypeBuilder eventTypeBuilder, ITypeDefinition typeDefinition)
            : base(typeDefinition) {
            this.eventTypeBuilder = eventTypeBuilder;
        }
    }
}
