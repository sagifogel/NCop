using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public abstract class ActionInterceptionArgs<TArg1, TArg2> : ActionInterceptionArgs<TArg1>
	{
        public TArg2 Arg2 { get; set; }
	}
}
