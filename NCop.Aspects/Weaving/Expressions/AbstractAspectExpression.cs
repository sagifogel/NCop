using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Aspects;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
	internal abstract class AbstractAspectExpression : IAspectExpression
	{
		private readonly IAspectDefinition aspectDefinition = null;

		internal AbstractAspectExpression(IAspectDefinition aspectDefinition) {
			this.aspectDefinition = aspectDefinition;
		}

		internal AbstractAspectExpression() {
		}

		public abstract IMethodScopeWeaver Reduce();

		public IAspectExpression Expression { get; set; }
	}
}
