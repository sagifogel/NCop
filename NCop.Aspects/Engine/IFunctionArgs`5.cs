using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> : IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult>
    {
        TArg5 Arg5 { get; set; }
    }
}
