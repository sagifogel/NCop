using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Pointcuts
{
    public class MethodCallPointcut : IPointcut
    {
        public MethodCallPointcut(MethodInfo[] methodInfos) {

        }

        public string Name { get; private set; }
    }
}
