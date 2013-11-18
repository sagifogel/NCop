using NCop.Aspects.Aspects;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class OnMethodBoundaryAspectExpression : IAspectExpression
    {   
        internal OnMethodBoundaryAspectExpression(IAspectDefinition aspectDefinition) {

        }

        public IMethodWeaver Reduce() {
            throw new NotImplementedException();
        }
    }
}
