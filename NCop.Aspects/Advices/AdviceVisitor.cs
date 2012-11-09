using NCop.Aspects.Engine;
using NCop.Core.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Advices
{
    public class AdviceVisitor
    {
        public IAdvice Visit(OnInvokeAdviceAttribute advice) {
            return advice;
        }

        public IAdvice Visit(OnSuccessAdviceAttribute advice) {
            return advice;
        }

        public IAdvice Visit(OnErrorAdviceAttribute advice) {
            return advice;
        }

        public IAdvice Visit(OnFinallyAdviceAttribute advice) {
            return advice;
        }
    }
}
