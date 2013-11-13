﻿using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public abstract class ActionInterceptionArgs<TArg1> : InterceptionArgs
	{
		public TArg1 Arg1 { get; protected set; }
	}
}