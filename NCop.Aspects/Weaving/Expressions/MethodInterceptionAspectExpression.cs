using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Aspects;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class MethodInterceptionAspectExpression : AbstractAspectExpression
    {
        internal MethodInterceptionAspectExpression(IAspectExpression expression, IAspectDefinition aspectDefinition = null)
            : base(expression, aspectDefinition) {
        }

        public override IAspcetWeaver Reduce(IAspectWeaverSettings settings) {
            return new MethodInterceptionAspectWeaver(expression, aspectDefinition, settings);
        }
    }
}
