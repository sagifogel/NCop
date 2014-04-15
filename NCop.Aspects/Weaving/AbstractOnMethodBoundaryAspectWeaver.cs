using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Composite.Weaving;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractOnMethodBoundaryAspectWeaver : AbstractMethodAspectWeaver
    {
        protected List<IMethodScopeWeaver> tryWeavers = null;
        protected IMethodScopeWeaver returnValueWeaver = null;
        protected readonly ILocalBuilderRepository localBuilderRepository = null;
        protected readonly IByRefArgumentsStoreWeaver byRefArgumentsStoreWeaver = null;

        internal AbstractOnMethodBoundaryAspectWeaver(IAspectWeaver nestedAspect, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectDefinition, aspectWeavingSettings) {
            IAdviceExpression selectedExpression = null;
            var catchWeavers = new List<IMethodScopeWeaver>();
            var entryWeavers = new List<IMethodScopeWeaver>();
            var finallyWeavers = new List<IMethodScopeWeaver>();
            Action<ILGenerator> restoreArgsIfNeededAction = null;
            IMethodScopeWeaver restoreArgsIfNeededScopeWeaver = null;
            var adviceWeavingSettings = new AdviceWeavingSettings(aspectWeavingSettings, argumentsWeavingSetings);

            ArgumentType = argumentsWeavingSetings.ArgumentType;
            tryWeavers = new List<IMethodScopeWeaver>() { nestedAspect };
            localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            byRefArgumentsStoreWeaver = aspectWeavingSettings.ByRefArgumentsStoreWeaver;
            restoreArgsIfNeededAction = byRefArgumentsStoreWeaver.RestoreArgsIfNeeded;
            restoreArgsIfNeededScopeWeaver = restoreArgsIfNeededAction.ToMethodScopeWeaver();

            if (adviceDiscoveryVistor.HasOnMethodEntryAdvice) {
                selectedExpression = ResolveOnMethodEntryAdvice();
                entryWeavers.Add(selectedExpression.Reduce(adviceWeavingSettings));
            }

            AddEntryScopeWeavers(entryWeavers);

            if (adviceDiscoveryVistor.HasOnMethodSuccessAdvice) {
                selectedExpression = ResolveOnMethodSuccessAdvice();
                tryWeavers.Add(selectedExpression.Reduce(adviceWeavingSettings));
            }

            if (argumentsWeavingSetings.IsFunction) {
                OnFunctionWeavingDetected();
            }

            if (adviceDiscoveryVistor.HasFinallyAdvice) {
                selectedExpression = ResolveFinallyAdvice();
                finallyWeavers.Add(selectedExpression.Reduce(adviceWeavingSettings));
                AddFinallyScopeWeavers(finallyWeavers);

                if (adviceDiscoveryVistor.HasOnMethodExceptionAdvice) {
                    var aspectMember = aspectRepository.GetAspectFieldByType(aspectDefinition.Aspect.AspectType);
                    var settings = new TryCatchFinallySettings(ArgumentType, localBuilderRepository);

                    selectedExpression = ResolveOnMethodExceptionAdvice();
                    catchWeavers.Add(restoreArgsIfNeededScopeWeaver);
                    catchWeavers.Add(selectedExpression.Reduce(adviceWeavingSettings));
                    weaver = new TryCatchFinallyAspectWeaver(settings, entryWeavers, tryWeavers, catchWeavers, finallyWeavers, returnValueWeaver);
                }
                else {
                    finallyWeavers.Insert(0, restoreArgsIfNeededScopeWeaver);
                    weaver = new OnMethodBoundaryTryFinallyAspectWeaver(entryWeavers, tryWeavers, finallyWeavers, returnValueWeaver);
                }
            }
            else {
                if (!byRefArgumentsStoreWeaver.ContainsByRefParams) {
                    var weavers = entryWeavers;

                    weavers.AddRange(tryWeavers);

                    if (returnValueWeaver.IsNotNull()) {
                        weavers.Add(returnValueWeaver);
                    }

                    weaver = new MethodScopeWeaversQueue(weavers);
                }
                else {
                    AddFinallyScopeWeavers(finallyWeavers);
                    finallyWeavers.Insert(0, restoreArgsIfNeededScopeWeaver);
                    weaver = new OnMethodBoundaryTryFinallyAspectWeaver(entryWeavers, tryWeavers, finallyWeavers, returnValueWeaver);
                }
            }
        }

        protected virtual void OnFunctionWeavingDetected() {
            returnValueWeaver = new TopGetReturnValueWeaver(aspectWeavingSettings, argumentsWeavingSetings);
        }

        protected virtual void AddEntryScopeWeavers(List<IMethodScopeWeaver> entryWeavers) { }

        protected virtual void AddFinallyScopeWeavers(List<IMethodScopeWeaver> finallyWeavers) { }

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

    }
}
