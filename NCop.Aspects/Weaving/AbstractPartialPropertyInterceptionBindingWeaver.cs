using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractPartialPropertyInterceptionBindingWeaver : AbstractPropertyInterceptionBindingWeaver
    {
        protected readonly IAspectExpression aspectExpression = null;

        internal AbstractPartialPropertyInterceptionBindingWeaver(IAspectExpression aspectExpression, IPropertyAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectDefinition, aspectWeavingSettings) {
            this.aspectExpression = aspectExpression;
        }
    }
}
