
namespace NCop.Weaving
{
    public abstract class AbstractPropertyMethodSingatureWeaver : AbstractMemberSignatureWeaver
    {
        protected readonly IPropertyTypeBuilder propertyBuilder = null;

        protected AbstractPropertyMethodSingatureWeaver(IPropertyTypeBuilder propertyBuilder, ITypeDefinition typeDefinition)
            : base(typeDefinition) {
            this.propertyBuilder = propertyBuilder;
        }
    }
}
