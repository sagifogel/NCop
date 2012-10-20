using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Pointcuts;

namespace NCop.Tests
{
    public class MethodMethodPointcutMatcherAttribute : MethodPointcutAttribute
    {
        public override IEnumerable<IPointcut> Visit(MethodInfo[] methods) {
            return methods.Select(method => {
                return new MethodCallPointcut(method);
            });
        }
    }
}
