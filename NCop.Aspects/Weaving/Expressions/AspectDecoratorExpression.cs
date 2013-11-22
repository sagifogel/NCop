using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class AspectDecoratorExpression : IAspectExpression
    {
        private readonly IMethodScopeWeaver weaver = null;

        public AspectDecoratorExpression(MethodInfo methodImplementation, Type implementationType, Type contractType) {
            weaver = new MethodDecoratorScopeWeaver(methodImplementation, implementationType, contractType);
        }

        public IMethodScopeWeaver Reduce() {
            return weaver;
        }
    }
}
