using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionArgs<TResult> : InterceptionArgs, IFunctionInterceptionArgs
	{
        public abstract void Invoke();
        public TResult ReturnValue { get; set; }
	}
}
