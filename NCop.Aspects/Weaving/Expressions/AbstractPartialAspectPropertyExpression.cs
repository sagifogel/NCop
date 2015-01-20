using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
    internal abstract class AbstractPartialAspectPropertyExpression : AbstractAspectPropertyExpression
    {
        protected readonly IAspectExpression aspectExpression = null;

        internal AbstractPartialAspectPropertyExpression(IAspectExpression aspectExpression, IPropertyAspectDefinition aspectDefinition = null)
            : base(aspectDefinition) {
            this.aspectExpression = aspectExpression;
        }
    }
}
