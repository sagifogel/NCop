using NCop.Aspects.Aspects;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using NCop.Core.Extensions;
using NCop.Aspects.Weaving.Expressions;
using NCop.Aspects.Advices;
using NCop.Composite.Weaving;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving
{
	internal class OnMethodBoundaryAspectWeaver : AbstractMethodAspectWeaver
	{
		internal OnMethodBoundaryAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings settings)
			: base(aspectDefinition, settings) {
			IAdviceExpression selectedExpression = null;
			var entryWeavers = new List<IMethodScopeWeaver>();
			var catchWeavers = new List<IMethodScopeWeaver>();
			var finallyWeavers = new List<IMethodScopeWeaver>();
			var newSettings = new AdviceWeavingSettings(aspectDefinition.Aspect.AspectType, settings, localBuilderRepository, null);
			var tryWeavers = new List<IMethodScopeWeaver>();

			if (adviceDiscoveryVistor.HasOnMethodEntryAdvice) {
				selectedExpression = ResolveOnMethodEntryAdvice();
				entryWeavers.Add(selectedExpression.Reduce(newSettings));
			}

			if (adviceDiscoveryVistor.HasOnMethodSuccessAdvice) {
				selectedExpression = ResolveOnMethodSuccessAdvice();
				tryWeavers.Add(selectedExpression.Reduce(newSettings));
			}

			if (adviceDiscoveryVistor.HasFinallyAdvice) {
				selectedExpression = ResolveFinallyAdvice();
				finallyWeavers.Add(selectedExpression.Reduce(newSettings));

				if (adviceDiscoveryVistor.HasOnMethodExceptionAdvice) {
					selectedExpression = ResolveOnMethodExceptionAdvice();
					catchWeavers.Add(selectedExpression.Reduce(newSettings));

					weaver = new TryCatchFinallyAspectWeaver(entryWeavers, tryWeavers, catchWeavers, finallyWeavers);
				}
				else {
					weaver = new TryFinallyAspectWeaver(entryWeavers, tryWeavers, finallyWeavers);
				}
			}
			else {
				weaver = new MethodScopeWeaversQueue(entryWeavers.Concat(tryWeavers));
			}
		}

		private IAdviceExpression ResolveOnMethodEntryAdvice() {
			IAdviceDefinition selectedAdviceDefinition = null;
			Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;
			var onMethodEntryAdvice = adviceDiscoveryVistor.OnMethodEntryAdvice;

			adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnMethodEntryAdvice);
			selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onMethodEntryAdvice));

			return adviceExpressionFactory(selectedAdviceDefinition);
		}

		private IAdviceExpression ResolveOnMethodSuccessAdvice() {
			IAdviceDefinition selectedAdviceDefinition = null;
			Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;
			var onMethodSuccessAdvice = adviceDiscoveryVistor.OnMethodSuccessAdvice;

			adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnMethodSuccessAdvice);
			selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onMethodSuccessAdvice));

			return adviceExpressionFactory(selectedAdviceDefinition);
		}

		private IAdviceExpression ResolveOnMethodExceptionAdvice() {
			IAdviceDefinition selectedAdviceDefinition = null;
			Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;
			var onMethodExceptionAdvice = adviceDiscoveryVistor.OnMethodExceptionAdvice;

			adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnMethodExceptionAdvice);
			selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onMethodExceptionAdvice));

			return adviceExpressionFactory(selectedAdviceDefinition);
		}

		private IAdviceExpression ResolveFinallyAdvice() {
			IAdviceDefinition selectedAdviceDefinition = null;
			Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;
			var finallyAdvice = adviceDiscoveryVistor.FinallyAdvice;

			adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.FinallyAdvice);
			selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(finallyAdvice));

			return adviceExpressionFactory(selectedAdviceDefinition);
		}

		public override ILGenerator Weave(ILGenerator ilGenerator) {
			return weaver.Weave(ilGenerator);
		}
	}
}
