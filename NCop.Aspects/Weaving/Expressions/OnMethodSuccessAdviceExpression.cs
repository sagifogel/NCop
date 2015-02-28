using NCop.Aspects.Advices;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class OnMethodSuccessAdviceExpression : AbstractAdviceExpression
    {
        internal OnMethodSuccessAdviceExpression(IAdviceDefinition adviceDefinition)
            : base(adviceDefinition) {
        }

        protected override AdviceType AdviceType {
            get {
                return AdviceType.OnMethodSuccessAdvice;
            }
        }

        public override IMethodScopeWeaver Reduce(IAdviceWeavingSettings adviceWeavingSettings) {
            return new OnMethodSuccessAdviceWeaver(adviceWeavingSettings);
        }
    }
}