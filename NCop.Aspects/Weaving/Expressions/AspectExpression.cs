using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class AspectExpression : IAspectExpression
    {
        private readonly IAspectExpression expression = null;
        private readonly IWeavingSettings weavingSettings = null;
        private readonly IAspectDefinitionCollection aspectsDefinitions = null;

        internal AspectExpression(IAspectExpression expression, IAspectDefinitionCollection aspectsDefinitions, IWeavingSettings weavingSettings) {
			this.expression = expression;
			this.weavingSettings = weavingSettings;
			this.aspectsDefinitions = aspectsDefinitions;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings settings) {
			return new AspectsWeaver(expression, aspectsDefinitions, weavingSettings);
        }
    }
}
