using NCop.Aspects.Advices;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class OnRemoveHandlerAdviceExpression : AbstractAdviceExpression
    {
        internal OnRemoveHandlerAdviceExpression(IAdviceDefinition adviceDefinition)
			: base(adviceDefinition) {
        }

		protected override AdviceType AdviceType {
			get {
				return AdviceType.OnRemoveHandlerAdvice;
			}
		}

        public override IMethodScopeWeaver Reduce(IAdviceWeavingSettings adviceWeavingSettings) {
            return new OnRemoveHandlerAdviceWeaver(adviceWeavingSettings);
        }
    }
}