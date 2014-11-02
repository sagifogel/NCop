using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Advices
{
    internal class OnSetPropertyInvokeAdviceDefinition : AbstractPropertyAdviceDefinition
    {
        internal OnSetPropertyInvokeAdviceDefinition(OnMethodInvokeAdviceAttribute advice, MethodInfo adviceMethod)
            : base(advice, adviceMethod) {
        }
    }
}
