using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingOnMethodBoundaryAspectExpression : AbstractAspectExpression
    {
        internal BindingOnMethodBoundaryAspectExpression(IAspectExpression expression, IAspectDefinition aspectDefinition)
            : base(expression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings ) {
            return new OnMethodBoundaryAspectWeaver(aspectDefinition, aspectWeavingSettings);
        }
    }
}
