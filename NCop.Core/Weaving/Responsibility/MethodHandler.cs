using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Weaving.Responsibility
{
    public abstract class MethodHandler
    {
        protected MethodHandler NextHandler;

        public MethodHandler SetNextHandler(MethodHandler nextHandler) {
            return this.NextHandler = nextHandler;
        }

        public abstract void Handle(MethodHandler methodHandler);
    }
}
