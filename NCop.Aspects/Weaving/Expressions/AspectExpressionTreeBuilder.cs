using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class AspectExpressionTreeBuilder : IBuilder<IAspectExpression>
    {
        private readonly IWeavingSettings weavingSettings = null;
        private readonly IAspectExpression decoratorAspect = null;
        private readonly Stack<IAspectExpressionBuilder> aspectsStack = null;
        private readonly IAspectDefinitionCollection aspectsDefinitions = null;

        internal AspectExpressionTreeBuilder(IAspectDefinitionCollection aspectDefinitions, IWeavingSettings weavingSettings) {
            var aspectVisitor = new AspectVisitor();
            IArgumentsWeavingSettings argumentsWeavingSettings = null;
            IEnumerable<IAspectExpressionBuilder> aspectExpressionBuilders = null;

            var aspectsByPriority = aspectDefinitions.OrderBy(aspect => aspect.Aspect.AspectPriority)
                                                     .ThenBy(aspect => {
                                                         var value = aspect.Aspect is OnMethodBoundaryAspectAttribute;
                                                         return Convert.ToInt32(!value);
                                                     });

            this.weavingSettings = weavingSettings;
            this.aspectsDefinitions = aspectDefinitions;
            aspectExpressionBuilders = aspectsByPriority.Select(definition => definition.Accept(aspectVisitor));
            aspectsStack = new Stack<IAspectExpressionBuilder>(aspectExpressionBuilders);
            argumentsWeavingSettings = aspectDefinitions.First().ToArgumentsWeavingSettings();
            decoratorAspect = aspectVisitor.GetDecorationAspectExpression(argumentsWeavingSettings);
        }

        public IAspectExpression Build() {
            var aspectExpression = decoratorAspect;
            Func<IAspectExpression, IAspectExpression> expressionFactory = (expression) => {
                return aspectsStack.Pop()
                                   .Build(expression);
            };

            aspectExpression = expressionFactory(decoratorAspect);

            while (aspectsStack.Count > 0) {
                aspectExpression = expressionFactory(aspectExpression);
            }

            return new AspectExpression(aspectExpression, aspectsDefinitions, weavingSettings);
        }
    }
}
