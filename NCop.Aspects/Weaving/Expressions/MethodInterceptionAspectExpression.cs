using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Aspects;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class MethodInterceptionAspectExpression : AbstractAspectExpression
	{
		internal MethodInterceptionAspectExpression(IAspectDefinition aspectDefinition)
			: base(aspectDefinition) {
		}

		public override IMethodScopeWeaver Reduce() {
			throw new NotImplementedException();
		}
	}
}
