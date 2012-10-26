using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Aspects.Interception
{
    public class MethodExecution : IJoinPoint, IMethodExecution
    {   
        public object Instance { get; private set; }

        public object[] Arguments { get; private set; }

        public Exception Exception { get; private set; }

        public MemberInfo TargetMember { get; private set; }
    }
}
