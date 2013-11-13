using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class AdviceArgs<TInstance> : IAdviceArgs
	{
		public MethodBase Method { get; protected set; }
        public TInstance Instance { get; protected set; }
        public Exception Exception { get; protected set; }		
	}
}
