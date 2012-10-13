using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Pointcuts
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public class MethodPointcutMatcherAttribute : PointcutMatcherAttribute
    {
        public override bool Match(object obj) {
            return base.Match(obj);
        }
    }
}
