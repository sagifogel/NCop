using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Framework
{
    public interface IMethodInterception : IMethodExecution, IPreventable
    {
        object Proceed();
    }
}
