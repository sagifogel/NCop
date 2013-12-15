using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Engine
{
    public class ActionExecutionArgsImpl<TInstance, TArg1, TArg2> : ActionExecutionArgs<TArg1, TArg2>, IActionArgs<TArg1, TArg2>
	{
	}
}
