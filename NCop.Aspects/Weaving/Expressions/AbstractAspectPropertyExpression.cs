using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
    internal abstract class AbstractAspectPropertyExpression : IAspectExpression
    {
        protected readonly IPropertyAspectDefinition aspectDefinition = null;

        internal AbstractAspectPropertyExpression(IPropertyAspectDefinition aspectDefinition = null) {
            this.aspectDefinition = aspectDefinition;
        }

        public abstract IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings);
    }
}
