using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
    public class MethodDecoratorWeaver : IMethodWeaver
    {
        private ITypeDefinition _typeDefinition = null;

        public MethodDecoratorWeaver(Type type, ITypeDefinition typeDefinition) {
            _typeDefinition = typeDefinition;
        }

        public MethodBuilder DefineMethod(TypeBuilder typeBuilder) {
            throw new NotImplementedException();
        }

        public ILGenerator WeaveMethodScope(ILGenerator ilGenerator) {
            throw new NotImplementedException();
        }

        public void WeaveEndMethod(ILGenerator ilGenerator) {
            throw new NotImplementedException();
        }
    }
}
