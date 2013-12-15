using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public interface IFunctionBinding<TInstance, TResult>
    {
        TResult Invoke(ref TInstance instance, IFunctionArgs<TResult> args);
    }
}
