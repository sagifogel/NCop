using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class AspectExpressionTreeBuilder : IBuilder<IAspectExpression>
	{
		private readonly IWeavingSettings weavingSettings = null; 
		private readonly IAspectExpression decoratorAspect = null;
		private readonly Stack<IAspectDefinition> aspectsStack = null;
		private readonly IAspectDefinitionCollection aspectDefinitions = null;

		internal AspectExpressionTreeBuilder(IAspectDefinitionCollection aspectDefinitions, IWeavingSettings weavingSettings) {
			var aspectsByPriority = aspectDefinitions.OrderBy(aspect => aspect.Aspect.AspectPriority)
													 .ThenBy(aspect => {
														 var value = aspect.Aspect is OnMethodBoundaryAspectAttribute;
														 return Convert.ToInt32(!value);
													 });

			this.weavingSettings = weavingSettings;
			this.aspectDefinitions = aspectDefinitions;
			aspectsStack = new Stack<IAspectDefinition>(aspectsByPriority);
			decoratorAspect = new AspectDecoratorExpression(weavingSettings);
		}

		public IAspectExpression Build() {
			var visitor = new AspectVisitor();
			IAspectExpressionBuilder builder = null;
			IAspectExpression aspectExpression = null;
			var aspectDefinition = aspectsStack.Pop();

			builder = aspectDefinition.Accept(visitor);
			aspectExpression = builder.Build(decoratorAspect);

			while (aspectsStack.Count > 0) {
				aspectDefinition = aspectsStack.Pop();
				builder = aspectDefinition.Accept(visitor);
				aspectExpression = builder.Build(aspectExpression);
			}

			return new AspectExpression(weavingSettings.ContractType, aspectExpression, aspectDefinitions);
		}
	}
}
