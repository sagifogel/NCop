using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public abstract class FunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TResult> : FunctionInterceptionArgs<TArg1, TArg2, TArg3, TResult>
	{
		protected TArg4 arg4;

		public TArg4 Arg4 {
			get {
				return arg4;
			}
			set {
				arg4 = value;
			}
		}
	}
}
