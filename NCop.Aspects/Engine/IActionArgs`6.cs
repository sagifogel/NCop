using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IActionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : IActionArgs<TArg1, TArg2, TArg3, TArg4, TArg5>
    {
        TArg6 Arg6 { get; set; }
    }
}
