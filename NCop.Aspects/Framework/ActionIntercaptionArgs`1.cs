using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public abstract class ActionInterceptionArgs<TInstance, TArg1> : AdviceArgs<TInstance>
	{
		public TArg1 Arg1 { get; protected set; }
	}
}
