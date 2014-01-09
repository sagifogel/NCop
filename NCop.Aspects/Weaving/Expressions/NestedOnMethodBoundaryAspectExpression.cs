using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Extensions;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class NestedOnMethodBoundaryAspectExpression : AbstractAspectExpression
    {
        internal NestedOnMethodBoundaryAspectExpression(IAspectExpression expression, IAspectDefinition aspectDefinition)
            : base(expression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var nestedWeaver = aspectExpression.Reduce(aspectWeavingSettings);

            return new NestedOnMethodBoundaryAspectWeaver(nestedWeaver, aspectDefinition, aspectWeavingSettings);
        }
    }
}
