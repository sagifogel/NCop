using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IActionInterceptionArgs<TArg1> : IActionArgs<TArg1>, IActionInterceptionArgs
    {
        void Invoke(TArg1 arg1);
    }
}
