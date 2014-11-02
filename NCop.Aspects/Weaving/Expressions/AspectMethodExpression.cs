using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class AspectMethodExpression : IAspectMethodExpression
	{
		private readonly IAspectMethodExpression aspectExpression = null;
		private readonly IAspectDefinitionCollection aspectsDefinitions = null;

		internal AspectMethodExpression(IAspectMethodExpression aspectExpression, IAspectDefinitionCollection aspectsDefinitions) {
			this.aspectExpression = aspectExpression;
			this.aspectsDefinitions = aspectsDefinitions;
		}

		public IAspectWeaver Reduce(IAspectMethodWeavingSettings aspectWeavingSettings) {
			return new AspectsWeaver(aspectExpression, aspectsDefinitions, aspectWeavingSettings);
		}
	}
}
