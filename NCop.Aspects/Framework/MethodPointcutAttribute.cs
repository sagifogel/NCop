using System;
using System.Collections.Generic;
using System.Reflection;
using NCop.Aspects.Engine;
using NCop.Aspects.Pointcuts;

namespace NCop.Aspects.Framework
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class MethodPointcutAttribute : AbstractPointcutAttribute
    {
        public abstract override IEnumerable<IPointcut> Visit(MethodInfo[] methods);
    }
}
