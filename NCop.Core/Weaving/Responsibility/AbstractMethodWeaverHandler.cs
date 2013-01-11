using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core.Weaving.Responsibility
{
    public abstract class AbstractMethodWeaverHandler : IMethodWeaverHandler
    {
        public AbstractMethodWeaverHandler(Type type, ITypeDefinition typeDefinition) {
            Type = type;
            TypeDefinition = TypeDefinition;
        }

        public abstract bool CanHandle { get; }

        protected Type Type { get; private set; }
        
       protected ITypeDefinition TypeDefinition { get; private set; }

        protected abstract IMethodWeaver HandleInternal(MethodInfo methodInfo);

        public IMethodWeaverHandler NextHandler { get; protected set; }

        public IMethodWeaverHandler SetNextHandler(IMethodWeaverHandler nextHandler) {
            return NextHandler = nextHandler;
        }

        public IMethodWeaver Handle(MethodInfo methodInfo) {
            if (CanHandle) {
                return HandleInternal(methodInfo);
            }

            return NextHandler.Handle(methodInfo);
        }
    }
}
