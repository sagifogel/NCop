using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> : IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>
    {
        TArg6 Arg6 { get; set; }
    }
}
