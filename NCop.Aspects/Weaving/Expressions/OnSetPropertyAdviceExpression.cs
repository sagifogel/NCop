using NCop.Aspects.Advices;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class OnSetPropertyAdviceExpression : AbstractAdviceExpression
    {
        internal OnSetPropertyAdviceExpression(IAdviceDefinition adviceDefinition)
            : base(adviceDefinition) {
        }
        protected override AdviceType AdviceType {
            get {
                return AdviceType.OnSetPropertyAdvice;
            }
        }

        public override IMethodScopeWeaver Reduce(IAdviceWeavingSettings adviceWeavingSettings) {
            return new OnSetPropertyAdviceWeaver(adviceWeavingSettings);
        }
    }
}
