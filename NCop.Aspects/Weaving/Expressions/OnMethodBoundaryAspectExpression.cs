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
    internal class OnMethodBoundaryAspectExpression : AbstractAspectExpression
    {
        internal OnMethodBoundaryAspectExpression(IAspectDefinition aspectDefinition)
            : base(aspectDefinition) {
            var adviceVisitor = new AdviceVisitor();
            var advices = aspectDefinition.Advices.Select(advice => advice.Advice);
            var advicesExpressions = advices.Select(advice => advice.Accept(adviceVisitor)).ToList();
        }

        public override IMethodScopeWeaver Reduce() {
            throw new NotImplementedException();
        }
    }
}
