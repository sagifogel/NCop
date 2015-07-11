using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractRemoveEventInterceptionAspectWeaver : AbstractInterceptionAspectWeaver
    {
        internal AbstractRemoveEventInterceptionAspectWeaver(IEventAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
        }

        protected override IAdviceExpression ResolveInterceptionAdviceExpression() {
            IAdviceDefinition selectedAdviceDefinition = null;
            var onRemoveHandlerAdvice = adviceDiscoveryVistor.OnRemoveHandlerAdvice;
            Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;

            adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnRemoveHandlerAdvice);
            selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onRemoveHandlerAdvice));

            return adviceExpressionFactory(selectedAdviceDefinition);
        }
    }
}
