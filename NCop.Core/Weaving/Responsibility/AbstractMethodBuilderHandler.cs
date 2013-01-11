using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Weaving.Responsibility
{
    public abstract class AbstractMethodBuilderHandler : IMethodBuilderHandler
    {
        public abstract bool CanHandle { get; }

        protected abstract IMethodWeaver HandleInternal(ITypeDefinition typeDefinition);

        public IMethodBuilderHandler NextHandler { get; protected set; }

        public IMethodBuilderHandler SetNextHandler(IMethodBuilderHandler nextHandler) {
            return NextHandler = nextHandler;
        }

        public IMethodWeaver Handle(ITypeDefinition typeDefinition) {
            if (CanHandle) {
                return HandleInternal(typeDefinition);
            }

            return NextHandler.Handle(typeDefinition);
        }
    }
}
