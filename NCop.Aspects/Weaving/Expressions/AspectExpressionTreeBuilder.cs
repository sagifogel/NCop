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
        private readonly Stack<IAspectDefinition> aspectsStack = null;
        private readonly IAspectDefinitionCollection aspectsDefinitions = null;

        internal AspectExpressionTreeBuilder(IAspectDefinitionCollection aspectDefinitions, IWeavingSettings weavingSettings) {
            var aspectsByPriority = aspectDefinitions.OrderBy(aspect => aspect.Aspect.AspectPriority)
                                                     .ThenBy(aspect => {
                                                         var value = aspect.Aspect is OnMethodBoundaryAspectAttribute;
                                                         return Convert.ToInt32(!value);
                                                     });

            this.weavingSettings = weavingSettings;
            this.aspectsDefinitions = aspectDefinitions;
            aspectsStack = new Stack<IAspectDefinition>(aspectsByPriority);
            decoratorAspect = new AspectDecoratorExpression(weavingSettings);
        }

        public IAspectExpression Build() {
            var aspectVisitor = new AspectVisitor();
            IAspectExpression aspectExpression = null;
            var topAspectVisitor = new TopAspectVisitor();
            var methodInfoImpl = weavingSettings.MethodInfoImpl;
            Func<IAspectDefinitionVisitor, IAspectExpression, IAspectExpression> expressionFactory = (visitor, expression) => {
                return aspectsStack.Pop()
                                   .Accept(visitor)
                                   .Build(expression);
            };

            aspectExpression = expressionFactory(aspectVisitor, decoratorAspect);

            while (aspectsStack.Count > 1) {
                aspectExpression = expressionFactory(aspectVisitor, aspectExpression);
            }

            aspectExpression = expressionFactory(topAspectVisitor, aspectExpression);

            return new AspectExpression(aspectExpression, aspectsDefinitions, weavingSettings);
        }
    }
}
