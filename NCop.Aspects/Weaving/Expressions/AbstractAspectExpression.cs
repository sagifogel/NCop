using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Aspects;
using NCop.Weaving;
using System.Reflection;
using NCop.Aspects.Advices;
using NCop.Core.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal abstract class AbstractAspectExpression : IAspectExpression
    {
        private readonly AdviceVisitor visitor = new AdviceVisitor();
        protected readonly IAspectDefinition aspectDefinition = null;
        protected readonly IEnumerable<IAdviceExpression> adviceExpressions = null;

        internal AbstractAspectExpression(IAspectExpression expression, IAspectDefinition aspectDefinition = null) {
            this.Expression = expression;

            if (aspectDefinition.IsNotNull()) {
                this.aspectDefinition = aspectDefinition;
                this.adviceExpressions = aspectDefinition.Advices.Select(advice => advice.Accept(visitor));
            }
        }

        internal IAspectExpression Expression { get; set; }

        public abstract IMethodScopeWeaver Reduce();
    }
}
