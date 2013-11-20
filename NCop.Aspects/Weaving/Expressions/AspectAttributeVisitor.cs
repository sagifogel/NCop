using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class AspectAttributeVisitor
	{
		internal IAspectExpression Visit(IAspectDefinition aspectDefinition) {
			switch (aspectDefinition.AspectType) {
				case AspectType.OnMethodBoundaryAspect:
					return VisitOnMethodBoundaryAspect(aspectDefinition);

				case AspectType.MethodInterceptionAspect:
					return VisitMethodInterceptionAspect(aspectDefinition);

				default:
					throw new NotSupportedException();
			}
		}

		private IAspectExpression VisitOnMethodBoundaryAspect(IAspectDefinition aspectDefinition) {
			return new OnMethodBoundaryAspectExpression(aspectDefinition);
		}

		private IAspectExpression VisitMethodInterceptionAspect(IAspectDefinition aspectDefinition) {
			return new MethodInterceptionAspectExpression(aspectDefinition);
		}
	}
}
