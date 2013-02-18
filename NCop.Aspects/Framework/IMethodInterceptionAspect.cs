using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public interface IMethodInterceptionAspect : IAspect
    {
        [OnMethodInvokeAdvice]
        void OnInvoke(IMethodInterception methodInterception);
    }
}
