using NCop.Aspects.Aspects;
using NCop.Aspects.Aspects.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class MethodInterceptionConcern : IMethodInterceptionContract
    {
        public abstract void OnInvoke(MethodInterception methodInterception);
    }
}
