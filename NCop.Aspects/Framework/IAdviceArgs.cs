using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Framework
{
    public interface IAdviceArgs
    {
        MethodBase Method { get; }
        Exception Exception { get; }        
    }
}
