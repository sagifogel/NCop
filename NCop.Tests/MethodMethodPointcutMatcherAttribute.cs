using NCop.Aspects.Engine;
using NCop.Aspects.Pointcuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;

namespace NCop.Tests
{
    public class MethodMethodPointcutMatcherAttribute : MethodPointcutProviderAttribute
    {
        public override IEnumerable<IPointcut> Visit(MethodInfo[] methods) {
            return methods.Select(method => {
                return new MethodCallPointcut(method);
            });
        }
    }
}
