using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class AspectDecoratorWeaver : IAspcetWeaver
    {
        private readonly IMethodScopeWeaver weaver = null;

        public AspectDecoratorWeaver(MethodInfo methodImplementation, Type implementationType, Type contractType) {
            weaver = new MethodDecoratorScopeWeaver(methodImplementation, implementationType, contractType);
        }

        public ILGenerator Weave(ILGenerator iLGenerator, ITypeDefinition typeDefinition) {
            return weaver.Weave(iLGenerator, typeDefinition);
        }
    }
}
