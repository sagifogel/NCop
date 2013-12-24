using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving.Expressions
{
    public class TopAspectVisitor : IAspectDefinitionVisitor
    {
        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(OnMethodBoundaryAspectAttribute aspect) {
            return (IAspectDefinition aspectDefinition) => {
                return new AspectNodeExpressionBuilder((IAspectExpression expression) => {
                    return new OnMethodBoundaryAspectExpression(expression, aspectDefinition);
                });
            };
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(MethodInterceptionAspectAttribute aspect) {
            return (IAspectDefinition aspectDefinition) => {
                return new AspectNodeExpressionBuilder((IAspectExpression expression) => {
                    return new MethodInterceptionTopAspectExpression(expression, aspectDefinition);
                });
            };
        }
    }
}
