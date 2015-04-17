using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionEventInterceptionArgs<TArg1, TArg2, TResult> : FunctionEventInterceptionArgs<TArg1, TResult>
    {
        public TArg2 Arg2 { get; set; }
    }
}
