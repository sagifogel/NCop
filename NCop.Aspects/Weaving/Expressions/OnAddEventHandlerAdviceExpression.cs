using NCop.Aspects.Advices;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class OnAddEventHandlerAdviceExpression : AbstractAdviceExpression
    {
        internal OnAddEventHandlerAdviceExpression(IAdviceDefinition adviceDefinition)
			: base(adviceDefinition) {
        }

		protected override AdviceType AdviceType {
			get {
				return AdviceType.OnAddHandlerAdvice;
			}
		}

        public override IMethodScopeWeaver Reduce(IAdviceWeavingSettings adviceWeavingSettings) {
            return new OnAddEventHandlerAdviceWeaver(adviceWeavingSettings);
        }
    }
}