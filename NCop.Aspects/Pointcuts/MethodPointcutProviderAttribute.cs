using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Pointcuts
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class MethodPointcutMatcherAttribute : AbstractPointcutMatcherAttribute
    {
        public abstract override IPointcut Visit(MethodInfo[] methods);

        public override bool Match(object obj) {
            return base.Match(obj);
        }
    }
}
