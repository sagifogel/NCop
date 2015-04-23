using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Framework
{
    public abstract class EventFunctionInterceptionArgs<TResult> : AbstractEventInterceptionArgs, IEventFunctionInterceptionArgs
    {
        public TResult ReturnValue { get; set; }
    }
}
