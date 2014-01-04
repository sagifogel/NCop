using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingAspectDecoratorExpression : IAspectExpression
    {
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal BindingAspectDecoratorExpression(IArgumentsWeavingSettings argumentsWeavingSettings) {
            this.argumentsWeavingSettings = argumentsWeavingSettings;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings ) {
            return new AspectDecoratorWeaver(aspectWeavingSettings, argumentsWeavingSettings);
        }
    }
}
