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
        private readonly IAspcetWeaver weaver = null;

        internal AspectDecoratorExpression(MethodInfo methodImplementation, Type implementationType, Type contractType) {
            weaver = new AspectDecoratorWeaver(methodImplementation, implementationType, contractType);
        }

        public IAspcetWeaver Reduce(IAspectWeaverSettings settings) {
            return weaver;
        }
    }
}
