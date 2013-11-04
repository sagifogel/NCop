using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public interface IActionBinding<TArg1, TArg2, TArg3>
    {
        void Invoke(ref object instance, TArg1 arg1, TArg2 arg2, TArg3 arg3);
    }
}
