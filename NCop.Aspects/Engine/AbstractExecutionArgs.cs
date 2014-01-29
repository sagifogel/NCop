using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractExecutionArgs : AdviceArgs
    {
        public FlowBehavior FlowBehavior { get; set; }

        public AbstractExecutionArgs() {
            FlowBehavior = FlowBehavior.RethrowException;
        }
    }
}
