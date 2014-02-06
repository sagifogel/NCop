using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> : FunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>
    {
		protected TArg6 arg6;

		public TArg6 Arg6 {
			get {
				return arg6;
			}
			set {
				arg6 = value;
			}
		}
    }
}
