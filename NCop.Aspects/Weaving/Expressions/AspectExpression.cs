using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Composite.Weaving;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class AspectExpression : IAspectExpression
    {
        private readonly IContextWeaver contextWeaver = null;
        private readonly IAspectExpression expression = null;
        private readonly IAspectDefinitionCollection aspectDefinitions = null;

        internal AspectExpression(Type contractType, IAspectExpression expression, IAspectDefinitionCollection aspectDefinitions) {
            this.expression = expression;
            contextWeaver = new ThisContextWeaver(contractType);
            this.aspectDefinitions = aspectDefinitions;
        }
        public IAspcetWeaver Reduce(IAspectWeaverSettings settings) {
            return new AspectsWeaver(expression, aspectDefinitions, contextWeaver);
        }
    }
}
