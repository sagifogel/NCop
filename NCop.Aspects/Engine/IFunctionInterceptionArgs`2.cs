using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IFunctionInterceptionArgs<TArg1, TArg2, TResult> : IFunctionArgs<TArg1, TArg2, TResult>, IFunctionInterceptionArgs
    {
        TResult Invoke(TArg1 arg1, TArg2 arg2);
    }
}
