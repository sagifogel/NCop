using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
    public interface IAdviceArgs
    {
        MethodInfo Method { get; }
        Exception Exception { get; }        
    }
}
