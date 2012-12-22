using NCop.Aspects.JoinPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    interface IInvocationJoinPoint : IJoinPoint
    {
        MethodInfo Method { get; }
        object[] Arguments { get; }
    }
}
