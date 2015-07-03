using NCop.Aspects.Advices;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class OnRemoveEventHandlerAdviceExpression : AbstractAdviceExpression
    {
        internal OnRemoveEventHandlerAdviceExpression(IAdviceDefinition adviceDefinition)
			: base(adviceDefinition) {
        }

		protected override AdviceType AdviceType {
			get {
				return AdviceType.OnRemoveHandlerAdvice;
			}
		}

        public override IMethodScopeWeaver Reduce(IAdviceWeavingSettings adviceWeavingSettings) {
            return new OnRemoveEventHandlerAdviceWeaver(adviceWeavingSettings);
        }
    }
}