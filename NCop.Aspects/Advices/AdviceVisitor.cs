using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Advices
{
    public class AdviceVisitor
    {
        public Func<MethodInfo, IExpressionReducer> Visit(OnMethodEntryAdviceAttribute advice) {
            return (adviceMethod) => {
                return new OnMethodEntryAdviceExpression(adviceMethod);
            };
        }

        public Func<MethodInfo, IExpressionReducer> Visit(OnMethodInvokeAdviceAttribute advice) {
            return (adviceMethod) => {
                return new OnMethodInvokeAdviceExpression(adviceMethod);
            };
        }

        public Func<MethodInfo, IExpressionReducer> Visit(OnMethodSuccessAdviceAttribute advice) {
            return (adviceMethod) => {
                return new OnMethodSuccessAdviceExpression(adviceMethod);
            };
        }

        public Func<MethodInfo, IExpressionReducer> Visit(OnMethodExceptionAdviceAttribute advice) {
            return (adviceMethod) => {
                return new OnMethodExceptionAdviceExpression(adviceMethod);
            };
        }

        public Func<MethodInfo, IExpressionReducer> Visit(FinallyAdviceAttribute advice) {
            return (adviceMethod) => {
                return new FinallyAdviceExpression(adviceMethod);
            };
        }
    }
}
