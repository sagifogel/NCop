using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
    internal abstract class AbstractAspectPropertyExpression : IAspectMethodExpression
    {
        protected readonly IAspectMethodExpression aspectExpression = null;
        protected readonly IPropertyAspectDefinition aspectDefinition = null;

        internal AbstractAspectPropertyExpression(IAspectMethodExpression aspectExpression, IPropertyAspectDefinition aspectDefinition = null) {
            this.aspectExpression = aspectExpression;
            this.aspectDefinition = aspectDefinition;
        }

        public abstract IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings);
    }
}
