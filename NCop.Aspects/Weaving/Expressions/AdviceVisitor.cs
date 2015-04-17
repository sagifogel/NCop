using NCop.Aspects.Advices;
using System;

namespace NCop.Aspects.Weaving.Expressions
{
    public class AdviceVisitor
    {
        internal Func<IAdviceDefinition, IAdviceExpression> Visit(FinallyAdviceAttribute advice) {
            return adviceDefinition => {
                return new FinallyAdviceExpression(adviceDefinition);
            };
        }

        internal Func<IAdviceDefinition, IAdviceExpression> Visit(OnAddHandlerAdviceAttribute advice) {
            return adviceDefinition => {
                return new OnAddHandlerAdviceExpression(adviceDefinition);
            };
        }

        internal Func<IAdviceDefinition, IAdviceExpression> Visit(OnGetPropertyAdviceAttribute advice) {
            return adviceDefinition => {
                return new OnGetPropertyAdviceExpression(adviceDefinition);
            };
        }

        internal Func<IAdviceDefinition, IAdviceExpression> Visit(OnSetPropertyAdviceAttribute advice) {
            return adviceDefinition => {
                return new OnSetPropertyAdviceExpression(adviceDefinition);
            };
        }

        internal Func<IAdviceDefinition, IAdviceExpression> Visit(OnMethodEntryAdviceAttribute advice) {
            return adviceDefinition => {
                return new OnMethodEntryAdviceExpression(adviceDefinition);
            };
        }

        internal Func<IAdviceDefinition, IAdviceExpression> Visit(OnMethodInvokeAdviceAttribute advice) {
            return adviceDefinition => {
                return new OnMethodInvokeAdviceExpression(adviceDefinition);
            };
        }

        internal Func<IAdviceDefinition, IAdviceExpression> Visit(OnRemoveHandlerAdviceAttribute advice) {
            return adviceDefinition => {
                return new OnRemoveHandlerAdviceExpression(adviceDefinition);
            };
        }

        internal Func<IAdviceDefinition, IAdviceExpression> Visit(OnInvokeHandlerAdviceAttribute advice) {
            return adviceDefinition => {
                return new OnInvokeHandlerAdviceExpression(adviceDefinition);
            };
        }

        internal Func<IAdviceDefinition, IAdviceExpression> Visit(OnMethodSuccessAdviceAttribute advice) {
            return adviceDefinition => {
                return new OnMethodSuccessAdviceExpression(adviceDefinition);
            };
        }

        internal Func<IAdviceDefinition, IAdviceExpression> Visit(OnMethodExceptionAdviceAttribute advice) {
            return adviceDefinition => {
                return new OnMethodExceptionAdviceExpression(adviceDefinition);
            };
        }
    }
}
