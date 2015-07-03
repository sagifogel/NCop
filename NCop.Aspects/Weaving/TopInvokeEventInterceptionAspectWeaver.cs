using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class TopInvokeEventInterceptionAspectWeaver : AbstractTopEventFragmentInterceptionAspectWeaver
    {
        internal TopInvokeEventInterceptionAspectWeaver(IEventAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            methodScopeWeavers.Add(new TopGetReturnValueWeaver(aspectWeavingSettings, argumentsWeavingSettings));
            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }

        protected override IAdviceExpression ResolveInterceptionAdviceExpression() {
            IAdviceDefinition selectedAdviceDefinition = null;
            var onInvokeHandlerAdvice = adviceDiscoveryVistor.OnInvokeHandlerAdvice;
            Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;

            adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnInvokeHandlerAdvice);
            selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onInvokeHandlerAdvice));

            return adviceExpressionFactory(selectedAdviceDefinition);
        }
    }
}
