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
            var bindingWeaver = new IsolatedFullPropertyInterceptionBindingWeaver(getAspectExpression, setAspectExpression, aspectDefinition, aspectWeavingSettings);

            return new TopBothAccessorsPropertyInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, bindingWeaver.WeavedType);
        }
    }
}