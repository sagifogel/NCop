using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public interface IFunctionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>
    {
        TResult Invoke(ref TInstance instance, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> args);
    }
}
