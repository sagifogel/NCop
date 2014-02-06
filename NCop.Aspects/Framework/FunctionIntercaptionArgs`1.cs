using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionArgs<TArg1, TResult> : FunctionInterceptionArgs<TResult>
    {
		protected TArg1 arg1;

		public TArg1 Arg1 {
			get {
				return arg1;
			}
			set {
				arg1 = value;
			}
		}
    }
}
