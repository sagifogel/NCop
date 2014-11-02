using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Weaving;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Advices
{
    internal class OnGetPropertyInvokeAdviceDefinition : AbstractPropertyAdviceDefinition
    {
        internal OnGetPropertyInvokeAdviceDefinition(OnMethodInvokeAdviceAttribute advice, MethodInfo adviceMethod)
            : base(advice, adviceMethod) {
        }
    }
}