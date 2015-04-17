using NCop.Aspects.Advices;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class OnAddHandlerAdviceExpression : AbstractAdviceExpression
    {
        internal OnAddHandlerAdviceExpression(IAdviceDefinition adviceDefinition)
			: base(adviceDefinition) {
        }

		protected override AdviceType AdviceType {
			get {
				return AdviceType.OnAddHandlerAdvice;
			}
		}

        public override IMethodScopeWeaver Reduce(IAdviceWeavingSettings adviceWeavingSettings) {
            return new OnAddHandlerAdviceWeaver(adviceWeavingSettings);
        }
    }
}