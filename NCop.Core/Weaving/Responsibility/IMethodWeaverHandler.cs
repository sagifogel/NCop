using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core.Weaving.Responsibility
{
    public interface IMethodWeaverHandler : IMethodWeaverMatcher
    {
        IMethodWeaverHandler SetNextHandler(IMethodWeaverHandler nextHanlder);
    }
}
