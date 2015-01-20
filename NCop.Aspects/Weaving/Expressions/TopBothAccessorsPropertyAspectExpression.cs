using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopBothAccessorsPropertyAspectExpression : AbstractAspectPropertyExpression
    {
        protected readonly IAspectExpression getAspectExpression = null;
        protected readonly IAspectExpression setAspectExpression = null;

        internal TopBothAccessorsPropertyAspectExpression(IAspectExpression getAspectExpression, IAspectExpression setAspectExpression, IPropertyAspectDefinition aspectDefinition = null)
            : base(aspectDefinition) {
            this.getAspectExpression = getAspectExpression;
            this.setAspectExpression = setAspectExpression;
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var clonedAspectWeavingSettings = aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });

            var bindingWeaver = new IsolatedBothAccessorsPropertyInterceptionBindingWeaver(getAspectExpression, setAspectExpression, aspectDefinition, clonedAspectWeavingSettings);

            return new TopBothAccessorsPropertyInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, bindingWeaver.WeavedType);
        }
    }
}