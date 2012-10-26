using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IMethodExecution
    {
        object Instance { get; }
        object[] Arguments { get; }
        Exception Exception { get; }
    }
}
