using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Framework;
using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class AspectExpressionTreeBuilder : IBuilder<IAspectExpression>
    {
        private readonly Stack<IAspectExpressionBuilder> aspectsStack = null;

        internal AspectExpressionTreeBuilder(IAspectDefinitionCollection aspectDefinitions) {
            var aspectVisitor = new AspectVisitor();
            IAspectDefinition lastAspectDefinition = null;
            IAspectExpressionBuilder invocationAspectBuilder = null;
            IArgumentsWeavingSettings argumentsWeavingSettings = null;
            List<IAspectExpressionBuilder> aspectExpressionBuilders = null;

            var aspectsByPriority = aspectDefinitions.OrderBy(aspect => aspect.Aspect.AspectPriority)
                                                     .ThenBy(aspect => {
                                                         var value = aspect.Aspect is OnMethodBoundaryAspectAttribute;
                                                         return Convert.ToInt32(!value);
                                                     });

            lastAspectDefinition = aspectDefinitions.First();
            argumentsWeavingSettings = lastAspectDefinition.ToArgumentsWeavingSettings();
            aspectExpressionBuilders = aspectsByPriority.ToList(definition => definition.BuildAdvices().Accept(aspectVisitor));
            invocationAspectBuilder = aspectVisitor.VisitLast(lastAspectDefinition, argumentsWeavingSettings);
            aspectExpressionBuilders.Add(invocationAspectBuilder);
            aspectsStack = new Stack<IAspectExpressionBuilder>(aspectExpressionBuilders);
        }

        public IAspectExpression Build() {
            IAspectExpression aspectExpression = null;

            while (aspectsStack.Count > 0) {
                var builder = aspectsStack.Pop();
                
                aspectExpression = builder.Build(aspectExpression);
            }

            return new AspectMethodExpression(aspectExpression);
        }
    }
}
