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
        private readonly IAspectDefinition topAspectInScopeDefinition = null;

        internal NestedOnMethodBoundaryAspectExpression(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectDefinition topAspectInScopeDefinition)
            : base(aspectExpression, aspectDefinition) {
            this.topAspectInScopeDefinition = topAspectInScopeDefinition;
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var topAspectInScopeArgType = topAspectInScopeDefinition.ToAspectArgumentImpl();
            var nestedWeaver = aspectExpression.Reduce(aspectWeavingSettings);

            return new NestedOnMethodBoundaryAspectWeaver(topAspectInScopeArgType, nestedWeaver, aspectDefinition, aspectWeavingSettings);
        }
    }
}
