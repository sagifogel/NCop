using NCop.Aspects.Engine;
using NCop.Aspects.JoinPoints;
using System;
using System.Reflection;

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
