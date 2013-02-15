using NCop.Aspects.Engine;
using NCop.Aspects.JoinPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Framework
{
    public class MethodInterception : IJoinPoint, IMethodInterception
    {   
        public object Proceed() {
            return null;
        }

        public object Instance { get; private set; }

        public bool IsPrevented { get; private set; }

        public object[] Arguments { get; private set; }

        public Exception Exception { get; private set; }

        public MemberInfo TargetMember { get; private set; }
    }
}
