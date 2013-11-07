using NCop.Aspects.Advices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class ActionInterceptionAspect
    {
        [OnMethodInvokeAdvice]
		public virtual void OnInvoke(ActionInterceptionArgs args) { }
    }
}
