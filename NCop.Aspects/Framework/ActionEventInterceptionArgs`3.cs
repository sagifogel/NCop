using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Framework
{
    public abstract class ActionEventInterceptionArgs<TArg1, TArg2, TArg3> : ActionEventInterceptionArgs<TArg1, TArg2>
    {
        public TArg3 Arg3 { get; set; }
    }
}
