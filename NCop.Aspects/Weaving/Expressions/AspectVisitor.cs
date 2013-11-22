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
        internal Func<IAspectDefinition, IAspectExpressionBuilder> Visit(OnMethodBoundaryAspectAttribute aspect) {
            return (IAspectDefinition aspectDefinition) => {
                return new AspectNodeExpressionBuilder((IAspectExpression expression) => {
                    return new OnMethodBoundaryAspectExpression(expression, aspectDefinition);
                });
            };
        }

        internal Func<IAspectDefinition, IAspectExpressionBuilder> Visit(MethodInterceptionAspectAttribute aspect) {
            return (IAspectDefinition aspectDefinition) => {
                return new AspectNodeExpressionBuilder((IAspectExpression expression) => {
                    return new MethodInterceptionAspectExpression(expression, aspectDefinition);
                });
            };
        }
    }
}
