using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class NestedAspectDecoratorExpression: IAspectExpression
    {
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal NestedAspectDecoratorExpression(IArgumentsWeavingSettings argumentsWeavingSettings) {
            this.argumentsWeavingSettings = argumentsWeavingSettings;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings ) {
            return new NestedAspectDecoratorWeaver(aspectWeavingSettings, argumentsWeavingSettings);
        }
    }
}
