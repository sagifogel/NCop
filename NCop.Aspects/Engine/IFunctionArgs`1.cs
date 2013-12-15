using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IFunctionArgs<TArg1, TResult> : IFunctionArgs<TResult>
    {
        TArg1 Arg1 { get; set; }
    }
}
