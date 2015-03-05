using NCop.Aspects.Advices;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class OnMethodInvokeAdviceExpression : AbstractAdviceExpression
    {
        internal OnMethodInvokeAdviceExpression(IAdviceDefinition adviceDefinition)
            : base(adviceDefinition) {
        }

        protected override AdviceType AdviceType {
            get {
                return AdviceType.OnMethodInvokeAdvice;
            }
        }

        public override IMethodScopeWeaver Reduce(IAdviceWeavingSettings adviceWeavingSettings) {
            return new OnMethodInvokeWeaver(adviceWeavingSettings);
        }
    }
}