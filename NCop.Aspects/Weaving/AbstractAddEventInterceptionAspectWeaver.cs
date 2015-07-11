using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractAddEventInterceptionAspectWeaver : AbstractInterceptionAspectWeaver
    {
        internal AbstractAddEventInterceptionAspectWeaver(IEventAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
        }

        protected override IAdviceExpression ResolveInterceptionAdviceExpression() {
            IAdviceDefinition selectedAdviceDefinition = null;
            var onAddHandlerAdvice = adviceDiscoveryVistor.OnAddHandlerAdvice;
            Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;

            adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnAddHandlerAdvice);
            selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onAddHandlerAdvice));

            return adviceExpressionFactory(selectedAdviceDefinition);
        }
    }
}
