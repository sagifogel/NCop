using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionEventInterceptionArgs<TArg1, TResult> : FunctionEventInterceptionArgs<TResult>
    {
        public TArg1 Arg1 { get; set; }
    }
}
