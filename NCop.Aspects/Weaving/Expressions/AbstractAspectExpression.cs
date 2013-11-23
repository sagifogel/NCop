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
        protected readonly IAspectExpression expression = null;
        protected readonly IAspectDefinition aspectDefinition = null;

        internal AbstractAspectExpression(IAspectExpression expression, IAspectDefinition aspectDefinition = null) {
            this.expression = expression;
            this.aspectDefinition = aspectDefinition;                            
        }

        public abstract IMethodScopeWeaver Reduce();
    }
}
