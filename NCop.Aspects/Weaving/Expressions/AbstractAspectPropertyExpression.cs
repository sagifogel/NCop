using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
    internal abstract class AbstractAspectPropertyExpression : IAspectExpression
    {
        protected readonly IAspectExpression aspectExpression = null;
        protected readonly IPropertyAspectDefinition aspectDefinition = null;

        internal AbstractAspectPropertyExpression(IAspectExpression aspectExpression, IPropertyAspectDefinition aspectDefinition = null) {
            this.aspectExpression = aspectExpression;
            this.aspectDefinition = aspectDefinition;
        }

        public abstract IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings);
    }
}
