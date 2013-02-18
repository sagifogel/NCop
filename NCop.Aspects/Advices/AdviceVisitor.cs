using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Advices
{
    public class AdviceVisitor
    {
        public IAdvice Visit(OnMethodEntryAdviceAttribute advice) {
            return advice;
        }

        public IAdvice Visit(OnMethodInvokeAdviceAttribute advice) {
            return advice;
        }

        public IAdvice Visit(OnMethodSuccessAdviceAttribute advice) {
            return advice;
        }

        public IAdvice Visit(OnMethodExceptionAdviceAttribute advice) {
            return advice;
        }

        public IAdvice Visit(FinallyAdviceAttribute advice) {
            return advice;
        }
    }
}
