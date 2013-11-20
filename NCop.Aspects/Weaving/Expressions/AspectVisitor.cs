using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Weaving.Expressions
{
    public class AspectVisitor
    {
        public Func<IAspectDefinition, IAspectExpression> Visit(OnMethodBoundaryAspectAttribute aspect) {
            return (IAspectDefinition aspectDefinition) => {
                return new OnMethodBoundaryAspectExpression(aspectDefinition);
            };
        }

        public Func<IAspectDefinition, IAspectExpression> Visit(MethodInterceptionAspectAttribute aspect) {
            return (IAspectDefinition aspectDefinition) => {
                return new MethodInterceptionAspectExpression(aspectDefinition);
            };
        }
    }
}
