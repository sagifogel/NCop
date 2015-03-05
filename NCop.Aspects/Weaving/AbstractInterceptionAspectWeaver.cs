using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractSetPropertyInterceptionAspectWeaver : AbstractInterceptionAspectWeaver
    {
        internal AbstractSetPropertyInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
        }

        protected override IAdviceExpression ResolveInterceptionAdviceExpression() {
            IAdviceDefinition selectedAdviceDefinition = null;
            var onSetPropertyAdvice = adviceDiscoveryVistor.OnSetPropertyAdvice;
            Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;

            adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnSetPropertyAdvice);
            selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onSetPropertyAdvice));

            return adviceExpressionFactory(selectedAdviceDefinition);
        }
    }
}