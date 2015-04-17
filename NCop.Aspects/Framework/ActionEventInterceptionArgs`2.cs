using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Framework
{
    public abstract class ActionEventInterceptionArgs<TArg1, TArg2> : ActionEventInterceptionArgs<TArg1>
    {
        public TArg2 Arg2 { get; set; }
    }
}
