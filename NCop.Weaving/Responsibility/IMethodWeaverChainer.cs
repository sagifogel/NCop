using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Weaving.Responsibility
{
    public interface IMethodWeaverChainer  : IMethodWeaverHandler
    {
        IMethodWeaverChainer SetNextHandler(IMethodWeaverChainer nextHanlder);
    }
}
