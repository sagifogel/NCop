using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class MethodDecoratorScopeWeaver : IMethodScopeWeaver
    {
        private readonly Type decoratedType = null;
        private readonly MethodInfo methodInfo = null;

        public MethodDecoratorScopeWeaver(MethodInfo methodInfo, Type decoratedType) {
            this.methodInfo = methodInfo;
            this.decoratedType = decoratedType;
        }

        public ILGenerator Weave(ILGenerator iLGenerator, ITypeDefinition typeDefinition) {
            return iLGenerator;
        }
    }
}
