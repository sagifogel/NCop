using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core.Weaving.Responsibility
{
    public abstract class AbstractMethodWeaverHandler : IMethodWeaverHandler, IMethodWeaverChainer
    {
        protected AbstractMethodWeaverHandler(Type type) {
            Type = type;
            TypeDefinition = TypeDefinition;
        }
        
        protected Type Type { get; private set; }

        public abstract bool CanHandle { get; protected set; }

        protected ITypeDefinition TypeDefinition { get; private set; }

        public IMethodWeaverChainer NextHandler { get; protected set; }

        public IMethodWeaverChainer SetNextHandler(IMethodWeaverChainer nextHandler) {
            return NextHandler = nextHandler;
        }

        public virtual IMethodWeaver Handle(MethodInfo methodInfo, ITypeDefinition typeDefinition) {
            if (CanHandle) {
                return HandleInternal(methodInfo, typeDefinition);
            }

            return NextHandler.Handle(methodInfo, typeDefinition);
        }

        protected abstract IMethodWeaver HandleInternal(MethodInfo methodInfo, ITypeDefinition typeDefinition);

    }
}
