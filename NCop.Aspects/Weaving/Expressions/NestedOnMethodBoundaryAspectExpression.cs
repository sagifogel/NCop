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
        private readonly IAspectDefinition previousAspectDefinition = null;

        internal NestedOnMethodBoundaryAspectExpression(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectDefinition previousAspectDefinition)
            : base(aspectExpression, aspectDefinition) {
            this.previousAspectDefinition = previousAspectDefinition;
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var previousAspectArgsType = previousAspectDefinition.ToAspectArgumentImpl();
            var nestedWeaver = aspectExpression.Reduce(aspectWeavingSettings);

            return new NestedOnMethodBoundaryAspectWeaver(previousAspectArgsType, nestedWeaver, aspectDefinition, aspectWeavingSettings);
        }
    }
}
