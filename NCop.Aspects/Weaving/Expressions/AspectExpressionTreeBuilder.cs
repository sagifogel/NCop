using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Aspects.Extensions;
using NCop.Core.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class AspectExpressionTreeBuilder : IBuilder<IAspectExpression>
    {
        private readonly IWeavingSettings weavingSettings = null;
        private readonly Stack<IAspectExpressionBuilder> aspectsStack = null;
        private readonly IAspectDefinitionCollection aspectsDefinitions = null;

        internal AspectExpressionTreeBuilder(IAspectDefinitionCollection aspectDefinitions, IWeavingSettings weavingSettings) {
            var aspectVisitor = new AspectVisitor();
            IAspectDefinition firstAspectDefinition = null;
            IAspectExpressionBuilder decoratorAspectBuilder = null;
            IArgumentsWeavingSettings argumentsWeavingSettings = null;
            List<IAspectExpressionBuilder> aspectExpressionBuilders = null;

            var aspectsByPriority = aspectDefinitions.OrderBy(aspect => aspect.Aspect.AspectPriority)
                                                     .ThenBy(aspect => {
                                                         var value = aspect.Aspect is OnMethodBoundaryAspectAttribute;
                                                         return Convert.ToInt32(!value);
                                                     });

            this.weavingSettings = weavingSettings;
            this.aspectsDefinitions = aspectDefinitions;
            firstAspectDefinition = aspectDefinitions.First();
            argumentsWeavingSettings = firstAspectDefinition.ToArgumentsWeavingSettings();
            aspectExpressionBuilders = aspectsByPriority.ToList(definition => definition.Accept(aspectVisitor));
            decoratorAspectBuilder = aspectVisitor.GetDecorationAspectExpression(firstAspectDefinition, argumentsWeavingSettings);
            aspectExpressionBuilders.Add(decoratorAspectBuilder);
            aspectsStack = new Stack<IAspectExpressionBuilder>(aspectExpressionBuilders);
        }

        public IAspectExpression Build() {
            IAspectExpression aspectExpression = null;

            while (aspectsStack.Count > 0) {
                var builder = aspectsStack.Pop();
                aspectExpression = builder.Build(aspectExpression);
            }

            return new AspectExpression(aspectExpression, aspectsDefinitions, weavingSettings);
        }
    }
}
