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
	internal abstract class AbstractMethodInterceptionAspectWeaver : AbstractMethodAspectWeaver, IBindingTypeReflector
	{
        protected readonly List<IMethodScopeWeaver> methodScopeWeavers = null;
        protected readonly ILocalBuilderRepository localBuilderRepository = null;

		internal AbstractMethodInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
			: base(aspectDefinition, aspectWeavingSettings) {
			IAdviceExpression selectedExpression = null;
			var argumentsWeavingSettings = aspectDefinition.ToArgumentsWeavingSettings();
			var aspectSettings = new AdviceWeavingSettings(aspectWeavingSettings, argumentsWeavingSettings);

			WeavedType = weavedType;
            selectedExpression = ResolveOnMethodInvokeAdvice();
            methodScopeWeavers = new List<IMethodScopeWeaver>();
            methodScopeWeavers.Add(selectedExpression.Reduce(aspectSettings));
            localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
		}

		public FieldInfo WeavedType { get; private set; }

		private IAdviceExpression ResolveOnMethodInvokeAdvice() {
			IAdviceDefinition selectedAdviceDefinition = null;
            var onMethodInvokeAdvice = adviceDiscoveryVistor.OnMethodInvokeAdvice;
            Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;

			adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnMethodInvokeAdvice);
			selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onMethodInvokeAdvice));

			return adviceExpressionFactory(selectedAdviceDefinition);
		}
	}
}
