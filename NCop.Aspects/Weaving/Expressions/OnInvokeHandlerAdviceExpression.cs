using NCop.Aspects.Advices;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class OnInvokeHandlerAdviceExpression : AbstractAdviceExpression
    {
        internal OnInvokeHandlerAdviceExpression(IAdviceDefinition adviceDefinition)
			: base(adviceDefinition) {
        }

		protected override AdviceType AdviceType {
			get {
				return AdviceType.OnInvokeHanlderAdvice;
			}
		}

        public override IMethodScopeWeaver Reduce(IAdviceWeavingSettings adviceWeavingSettings) {
            return new OnInvokeHandlerAdviceWeaver(adviceWeavingSettings);
        }
    }
}