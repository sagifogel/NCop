using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
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
        internal AspectExpression(IEnumerable<IAspectDefinition> aspectDefinitions) {
            var aspectsByPriority = aspectDefinitions.OrderBy(aspect => aspect.Aspect.AspectPriority)
                                                     .ThenBy(aspect => {
                                                         var value = aspect.Aspect is OnMethodBoundaryAspectAttribute;
                                                         return Convert.ToInt32(!value);
                                                     });
        }

        public IMethodWeaver Reduce() {
            throw new NotImplementedException();
        }
    }
}
