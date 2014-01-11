using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Aspects;
using NCop.Weaving;
using System.Reflection;
using NCop.Aspects.Advices;
using NCop.Core.Extensions;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Weaving.Expressions
{
    internal abstract class AbstractAspectExpression : IAspectExpression
    {
        protected readonly IAspectExpression aspectExpression = null;
        protected readonly IAspectDefinition aspectDefinition = null;

        internal AbstractAspectExpression(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition = null) {
            this.aspectExpression = aspectExpression;
            this.aspectDefinition = aspectDefinition;
        }

        public abstract IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings );
    }
}