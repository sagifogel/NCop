using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult> : IFunctionArgs<TArg1, TArg2, TArg3, TResult>
    {
        TArg4 Arg4 { get; set; }
    }
}
