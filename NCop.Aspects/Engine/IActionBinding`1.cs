using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public interface IActionBinding<TInstance, TArg1>
    {
        void Invoke(ref TInstance instance, TArg1 arg1);
    }
}
