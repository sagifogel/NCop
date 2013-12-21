using NCop.Aspects.Weaving.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    internal class AspectExpressionVisitor
    {
        private readonly IAspectWeavingSettings settings = null;

        internal AspectExpressionVisitor(IAspectWeavingSettings  settings) {
            this.settings = settings;
        }

        internal IAspectWeaver Visit(AspectDecoratorExpression expression) {
            return expression.Reduce(settings);
        }

        internal IAspectWeaver Visit(OnMethodBoundaryAspectExpression expression) {
            return expression.Reduce(settings);
        }

        internal IAspectWeaver Visit(MethodInterceptionAspectExpression expression) {
            return expression.Reduce(settings);
        }
    }
}
