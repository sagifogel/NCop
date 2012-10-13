using NCop.Aspects.Engine;
using NCop.Aspects.Pointcuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Tests
{
    public class MethodMethodPointcutMatcherAttribute : MethodPointcutMatcherAttribute
    {
        public override IPointcut Visit(MethodInfo[] methods) {
            return new MethodCallPointcut(methods);
        }
    }
}
