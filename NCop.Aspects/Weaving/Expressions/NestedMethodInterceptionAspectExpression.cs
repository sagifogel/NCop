using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Aspects;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class NestedMethodInterceptionAspectExpression : AbstractAspectExpression
    {
        internal NestedMethodInterceptionAspectExpression(IAspectExpression expression, IAspectDefinition aspectDefinition)
            : base(expression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings settings) {
            var reducer = new MethodInterceptionAspectWeaverWithBinding(expression, aspectDefinition, settings);

            return reducer.Reduce(settings);
        }
    }
}