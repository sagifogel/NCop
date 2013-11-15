using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionExecutionArgsImpl<TResult> : FunctionExecutionArgs<TResult>
    {
        public FunctionExecutionArgsImpl(object instance) {
            Instance = instance;
        }
    }
}
