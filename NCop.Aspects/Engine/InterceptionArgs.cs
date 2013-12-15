using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
	public abstract class InterceptionArgs : AdviceArgs
    {
        public abstract void Proceed();
    }
}
