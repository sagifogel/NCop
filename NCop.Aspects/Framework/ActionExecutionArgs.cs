using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class ActionExecutionArgs : MethodExecutionArgs, IActionExecutionArgs
    {   
        public abstract void Proceed();
    }
}
