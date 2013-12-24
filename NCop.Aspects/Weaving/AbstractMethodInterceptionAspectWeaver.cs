using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using NCop.Composite.Weaving;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractMethodInterceptionAspectWeaver : AbstractMethodAspectWeaver, ITypeReflector
    {
        internal AbstractMethodInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings settings, FieldInfo weavedType)
            : base(aspectDefinition, settings) {
            IAdviceExpression selectedExpression = null;
            var invokeWeavers = new List<IMethodScopeWeaver>();
            var argumentsWeavingSettings = aspectDefinition.ToArgumentsWeavingSettings(settings.WeavingSettings.MethodInfoImpl.DeclaringType);
            var aspectSettings = new AdviceWeavingSettings(aspectDefinition.Aspect.AspectType, settings, localBuilderRepository, argumentsWeavingSettings);

            WeavedType = weavedType;
            selectedExpression = ResolveOnMethodInvokeAdvice();
            invokeWeavers.Add(selectedExpression.Reduce(aspectSettings));
            weaver = new MethodScopeWeaversQueue(invokeWeavers);
        }

        public FieldInfo WeavedType { get; private set; }

        private IAdviceExpression ResolveOnMethodInvokeAdvice() {
            IAdviceDefinition selectedAdviceDefinition = null;
            Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;
            var onMethodInvokeAdvice = adviceDiscoveryVistor.OnMethodInvokeAdvice;

            adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnMethodInvokeAdvice);
            selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onMethodInvokeAdvice));

            return adviceExpressionFactory(selectedAdviceDefinition);
        }
    }
}
