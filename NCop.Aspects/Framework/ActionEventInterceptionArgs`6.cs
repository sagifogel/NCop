using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Framework
{
    public abstract class ActionEventInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : ActionEventInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5>
    {
        public TArg6 Arg6 { get; set; }
    }
}
