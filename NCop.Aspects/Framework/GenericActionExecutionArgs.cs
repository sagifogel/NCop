using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class GenericActionExecutionArgs : AbstractAdviceArgs
	{
		public Arguments Arguments { get; set; }
    }
}
