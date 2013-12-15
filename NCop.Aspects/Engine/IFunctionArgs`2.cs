using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IFunctionArgs<TArg1, TArg2, TResult> : IFunctionArgs<TArg1, TResult>
    {
        TArg2 Arg2 { get; set; }
    }
}
