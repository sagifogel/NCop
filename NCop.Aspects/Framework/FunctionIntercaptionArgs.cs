using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionArgs<TInstance, TResult>
	{
		public TResult ReturnValue { get; protected set; }
	}
}
