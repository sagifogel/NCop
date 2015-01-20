using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving.Expressions
{
    internal abstract class AbstractAspectPropertyExpression : IAspectExpression
    {
        protected readonly IPropertyAspectDefinition aspectDefinition = null;

        internal AbstractAspectPropertyExpression(IPropertyAspectDefinition aspectDefinition = null) {
            this.aspectDefinition = aspectDefinition;
        }

        public abstract IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings);
    }
}
