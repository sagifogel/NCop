using NCop.Aspects.Advices;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class OnGetPropertyAdviceExpression : AbstractAdviceExpression
    {
        internal OnGetPropertyAdviceExpression(IAdviceDefinition adviceDefinition)
            : base(adviceDefinition) {
        }
        protected override AdviceType AdviceType {
            get {
                return AdviceType.OnGetPropertyAdvice;
            }
        }

        public override IMethodScopeWeaver Reduce(IAdviceWeavingSettings adviceWeavingSettings) {
            return new OnGetPropertyAdviceWeaver(adviceWeavingSettings);
        }
    }
}
