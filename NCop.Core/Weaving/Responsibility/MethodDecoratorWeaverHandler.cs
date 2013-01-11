using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Weaving.Responsibility
{
    public class MethodDecoratorWeaverHandler : AbstractMethodBuilderHandler
    {
        private Type _type;
        private ITypeDefinition _typeDefinition;

        public MethodDecoratorWeaverHandler(Type type, ITypeDefinition typeDefinition) {
            _type = type;
            _typeDefinition = typeDefinition;
        }

        public override bool CanHandle {
            get {
                return true;
            }
        }

        protected override IMethodWeaver HandleInternal(ITypeDefinition typeDefinition) {
            throw new NotImplementedException();
        }
    }
}
