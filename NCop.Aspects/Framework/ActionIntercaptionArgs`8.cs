using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public abstract class ActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> : ActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
	{
		protected TArg8 arg8;

		public TArg8 Arg8 {
			get {
				return arg8;
			}
			set {
				arg8 = value;
			}
		}
	}
}
