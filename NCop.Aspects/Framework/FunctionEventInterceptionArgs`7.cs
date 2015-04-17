using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionEventInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> : FunctionEventInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>
    {
        public TArg7 Arg7 { get; set; }
    }
}
