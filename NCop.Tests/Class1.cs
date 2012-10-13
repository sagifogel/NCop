using NCop.Aspects.Aspects;
using NCop.Aspects.Pointcuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Tests
{
    class Class1
    {
        [MethodMethodPointcutMatcherAttribute]
        static void Method() {
        }
    }
}
