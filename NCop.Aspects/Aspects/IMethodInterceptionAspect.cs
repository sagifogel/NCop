using NCop.Aspects.Advices;
using NCop.Aspects.Aspects.Interception;
using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Aspects
{
    public interface IMethodInterceptionAspect : IAspect
    {
        [OnInvokeAdvice]
        void OnInvoke(IMethodInterception methodInterception);
    }
}
