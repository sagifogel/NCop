using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Aspects;
using NCop.Aspects.Advices;
using NCop.Aspects.Aspects.Interception;

namespace NCop.Aspects.Framework
{
    public class SetPropertyInterceptionAspectAttribute : PropertyInterceptionAspectAttribute
    {
        [OnInvokeAdvice]
        public virtual void OnInvoke(SetPropertyInterception setPropertyInterception) { }
    }
}
