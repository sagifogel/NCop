using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IActionInterceptionArgs<TArg1, TArg2> : IActionArgs<TArg1, TArg2>, IActionInterceptionArgs
    {
        void Invoke(TArg1 arg1, TArg2 arg2);
    }
}
