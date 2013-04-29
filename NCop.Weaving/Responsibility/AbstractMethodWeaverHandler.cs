using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Weaving.Responsibility
{
    public abstract class AbstractMethodWeaverHandler : IMethodWeaverHandler, IMethodWeaverChainer
    {
        protected AbstractMethodWeaverHandler(Type type) {
            Type = type;
        }

        protected Type Type { get; private set; }

        public IMethodWeaverChainer NextHandler { get; protected set; }

        public IMethodWeaverChainer SetNextHandler(IMethodWeaverChainer nextHandler) {
            return NextHandler = nextHandler;
        }

        public abstract IMethodWeaver Handle(MethodInfo methodInfo, ITypeDefinition typeDefinition);
    }
}
