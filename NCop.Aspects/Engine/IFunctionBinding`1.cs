using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public interface IFunctionBinding<TArg1, TResult>
    {
        TResult Invoke(ref object instance, TArg1 arg1);
    }
}
