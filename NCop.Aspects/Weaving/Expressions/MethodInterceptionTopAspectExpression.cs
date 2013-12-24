using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class MethodInterceptionTopAspectExpression : AbstractAspectExpression
    {
        internal MethodInterceptionTopAspectExpression(IAspectExpression expression, IAspectDefinition aspectDefinition = null) 
            : base(expression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings settings) {
            var reducer = new AspectWeaverWithBinding(expression, aspectDefinition, settings);

            return reducer.Reduce(settings);
        }
    }
}
