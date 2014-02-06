using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public abstract class FunctionInterceptionArgs<TArg1, TArg2, TArg3, TResult> : FunctionInterceptionArgs<TArg1, TArg2, TResult>
	{
		protected TArg3 arg3;

		public TArg3 Arg3 {
			get {
				return arg3;
			}
			set {
				arg3 = value;
			}
		}
	}
}
