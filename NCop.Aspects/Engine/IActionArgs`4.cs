using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IActionArgs<TArg1, TArg2, TArg3, TArg4> : IActionArgs<TArg1, TArg2, TArg3> 
    {
        TArg4 Arg4 { get; set; }
    }
}
