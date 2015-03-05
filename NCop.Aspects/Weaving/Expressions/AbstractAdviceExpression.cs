using NCop.Aspects.Advices;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
    internal abstract class AbstractAdviceExpression : IAdviceExpression
    {
        protected readonly IAdviceDefinition adviceDefinition = null;

        internal AbstractAdviceExpression(IAdviceDefinition adviceDefinition) {
            this.adviceDefinition = adviceDefinition;
        }

        protected abstract AdviceType AdviceType { get; }

        public abstract IMethodScopeWeaver Reduce(IAdviceWeavingSettings adviceWeavingSettings);
    }
}
