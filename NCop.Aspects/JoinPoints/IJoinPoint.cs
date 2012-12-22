using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.JoinPoints
{
    public interface IJoinPoint
    {
        MemberInfo TargetMember { get; }
    }
}
