using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
    public class MethodDecoratorWeaver : IMethodWeaver
    {
        private Type _decoratedType = null;
        private ITypeDefinition _typeDefinition = null;

        public MethodDecoratorWeaver(MethodInfo methodInfo, Type decoratedType, ITypeDefinition typeDefinition) {
            MethodInfo = methodInfo;
            _decoratedType = decoratedType;
            _typeDefinition = typeDefinition;
        }

        public MethodInfo MethodInfo { get; private set; }

        public MethodBuilder DefineMethod() {
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
