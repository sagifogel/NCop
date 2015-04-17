using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionEventInterceptionArgs<TArg1, TArg2, TArg3, TResult> : FunctionEventInterceptionArgs<TArg1, TArg2, TResult>
    {
        public TArg3 Arg3 { get; set; }
    }
}
