using NCop.Aspects.Advices;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class FinallyAdviceExpression : AbstractAdviceExpression
    {
        internal FinallyAdviceExpression(IAdviceDefinition adviceDefinition)
			: base(adviceDefinition) {
        }

		protected override AdviceType AdviceType {
			get {
				return AdviceType.FinallyAdvice;
			}
		}

        public override IMethodScopeWeaver Reduce(IAdviceWeavingSettings adviceWeavingSettings) {
            return new FinallyAdviceWeaver(adviceWeavingSettings);
        }
    }
}