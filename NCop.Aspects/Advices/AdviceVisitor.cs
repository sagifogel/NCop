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
        public IAdvice Visit(OnEntryAdviceAttribute advice) {
            return advice;
        }

        public IAdvice Visit(OnInvokeAdviceAttribute advice) {
            return advice;
        }

        public IAdvice Visit(OnSuccessAdviceAttribute advice) {
            return advice;
        }

        public IAdvice Visit(OnExceptionAdviceAttribute advice) {
            return advice;
        }

        public IAdvice Visit(FinallyAdviceAttribute advice) {
            return advice;
        }
    }
}
