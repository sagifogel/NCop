using System;
using System.Reflection;
using NCop.Aspects.Advices;

namespace NCop.Aspects.Weaving.Expressions
{
    public class AdviceVisitor
    {
		public Func<IAdviceDefinition, IExpressionReducer> Visit(OnMethodEntryAdviceAttribute advice) {
			return (adviceDefinition) => {
				return new OnMethodEntryAdviceExpression(adviceDefinition);
            };
        }

        public Func<IAdviceDefinition, IExpressionReducer> Visit(OnMethodInvokeAdviceAttribute advice) {
			return (adviceDefinition) => {
				return new OnMethodInvokeAdviceExpression(adviceDefinition);
            };
        }

		public Func<IAdviceDefinition, IExpressionReducer> Visit(OnMethodSuccessAdviceAttribute advice) {
			return (adviceDefinition) => {
				return new OnMethodSuccessAdviceExpression(adviceDefinition);
            };
        }

		public Func<IAdviceDefinition, IExpressionReducer> Visit(OnMethodExceptionAdviceAttribute advice) {
			return (adviceDefinition) => {
				return new OnMethodExceptionAdviceExpression(adviceDefinition);
            };
        }

		public Func<IAdviceDefinition, IExpressionReducer> Visit(FinallyAdviceAttribute advice) {
			return (adviceDefinition) => {
				return new FinallyAdviceExpression(adviceDefinition);
            };
        }
    }
}
