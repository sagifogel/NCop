using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> : FunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TResult>
	{
		protected TArg5 arg5;

		public TArg5 Arg5 {
			get {
				return arg5;
			}
			set {
				arg5 = value;
			}
		}
    }
}
