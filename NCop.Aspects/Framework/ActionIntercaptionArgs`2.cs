using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class ActionInterceptionArgs<TArg1, TArg2> : InterceptionArgs, IActionInterceptionArgs<TArg1, TArg2>
    {
        public TArg1 Arg1 { get; set; }
        public TArg2 Arg2 { get; set; }
        public abstract void Invoke(TArg1 arg1, TArg2 arg2);
    }
}
