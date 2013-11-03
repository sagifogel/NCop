using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public class GenericActionExecutionArgs : ActionExecutionArgs
	{
		public Arguments Arguments { get; protected set; }
	}
}
