using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class OnMethodBoundaryAspectExpression : AbstractAspectExpression
    {
        internal OnMethodBoundaryAspectExpression(IAspectDefinition aspectDefinition)
            : base(aspectDefinition) {
            var adviceVisitor = new AdviceVisitor();
        }

        public override IMethodScopeWeaver Reduce() {
            throw new NotImplementedException();
        }
    }
}
