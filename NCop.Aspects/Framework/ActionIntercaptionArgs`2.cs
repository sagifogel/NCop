using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public abstract class ActionInterceptionArgs<TArg1, TArg2> : ActionInterceptionArgs<TArg1>
	{
		protected TArg2 arg2;

		public TArg2 Arg2 {
			get {
				return arg2;
			}
			set {
				arg2 = value;
			}
		}
	}
}
