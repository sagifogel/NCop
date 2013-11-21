using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Aspects;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal abstract class AbstractAspectExpression : IHasAspectExpression, IExpressionReducer
	{
		private readonly IAspectDefinition aspectDefinition = null;

		internal AbstractAspectExpression(IAspectDefinition aspectDefinition) {
            this.aspectDefinition = aspectDefinition;
		}

		internal AbstractAspectExpression() {
		}

		public abstract IMethodScopeWeaver Reduce();

		public IHasAspectExpression Expression { get; set; }
	}
}
