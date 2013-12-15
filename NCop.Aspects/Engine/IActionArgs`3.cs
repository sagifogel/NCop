using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IActionArgs<TArg1, TArg2, TArg3> : IActionArgs<TArg1, TArg2>
    {
        TArg3 Arg3 { get; set; }
    }
}
