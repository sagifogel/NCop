using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public interface IActionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    {
        void Invoke(ref TInstance instance, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6);
    }
}
