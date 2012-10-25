using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    interface IInvocationJointPoint : IJointPoint
    {
        MethodInfo Method { get; }
        object[] Arguments { get; }
    }
}
