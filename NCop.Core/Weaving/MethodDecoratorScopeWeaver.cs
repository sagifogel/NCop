using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
    public class MethodDecoratorScopeWeaver : IMethodScopeWeaver
    {
        private readonly Type _decoratedType = null;
        private readonly MethodInfo _methodInfo = null;

        public MethodDecoratorScopeWeaver(MethodInfo methodInfo, Type decoratedType) {
            _methodInfo = methodInfo;
            _decoratedType = decoratedType;
        }

        public ILGenerator Weave(ILGenerator iLGenerator, ITypeDefinition typeDefinition) {
            return iLGenerator;
        }
    }
}
