using System;
using System.Reflection;
using NCop.Aspects.Advices;

namespace NCop.Aspects.Weaving.Expressions
{
    public class AdviceVisitor
    {
        internal Func<IAdviceDefinition, IAdviceExpression> Visit(FinallyAdviceAttribute advice) {
            return (adviceDefinition) => {
                return new FinallyAdviceExpression(adviceDefinition);
            };
        }
        
        internal Func<IAdviceDefinition, IAdviceExpression> Visit(OnMethodEntryAdviceAttribute advice) {
            return (adviceDefinition) => {
                return new OnMethodEntryAdviceExpression(adviceDefinition);
            };
        }

        internal Func<IAdviceDefinition, IAdviceExpression> Visit(OnMethodInvokeAdviceAttribute advice) {
            return (adviceDefinition) => {
                return new OnMethodInvokeAdviceExpression(adviceDefinition);
            };
        }

        internal Func<IAdviceDefinition, IAdviceExpression> Visit(OnMethodSuccessAdviceAttribute advice) {
            return (adviceDefinition) => {
                return new OnMethodSuccessAdviceExpression(adviceDefinition);
            };
        }

        internal Func<IAdviceDefinition, IAdviceExpression> Visit(OnMethodExceptionAdviceAttribute advice) {
            return (adviceDefinition) => {
                return new OnMethodExceptionAdviceExpression(adviceDefinition);
            };
        }
    }
}
