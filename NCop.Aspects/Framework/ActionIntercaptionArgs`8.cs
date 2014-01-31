using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class ActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> : InterceptionArgs, IActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
	{
        public TArg1 Arg1 { get; set; }
        public TArg2 Arg2 { get; set; }
        public TArg3 Arg3 { get; set; }
        public TArg4 Arg4 { get; set; }
        public TArg5 Arg5 { get; set; }
        public TArg6 Arg6 { get; set; }
        public TArg7 Arg7 { get; set; }
        public TArg8 Arg8 { get; set; }
        public abstract void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8);
    }
}
