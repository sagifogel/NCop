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
        protected readonly List<IMethodScopeWeaver> methodScopeWeavers = null;
        protected readonly ILocalBuilderRepository localBuilderRepository = null;

		internal AbstractMethodInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
			: base(aspectDefinition, aspectWeavingSettings) {
			IAdviceExpression selectedExpression = null;
			var argumentsWeavingSettings = aspectDefinition.ToArgumentsWeavingSettings();
			var aspectSettings = new AdviceWeavingSettings(aspectDefinition.Aspect.AspectType, aspectWeavingSettings, aspectWeavingSettings.LocalBuilderRepository, argumentsWeavingSettings);

			WeavedType = weavedType;
            methodScopeWeavers = new List<IMethodScopeWeaver>();
            selectedExpression = ResolveOnMethodInvokeAdvice();
			localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            methodScopeWeavers.Add(selectedExpression.Reduce(aspectSettings));			
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
