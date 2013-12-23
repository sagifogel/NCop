using System;
using System.Linq;
using System.Reflection.Emit;
using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractMethodAspectWeaver : IAspectWeaver
    {
        protected IMethodScopeWeaver weaver = null;
        protected readonly IArgumentsWeaver argumentsWeaver = null;
        protected readonly IAspectRepository aspectRepository = null;
        protected readonly IAspectDefinition aspectDefinition = null;
        protected readonly IAdviceDefinitionCollection advices = null;
        protected readonly AdviceVisitor adviceVisitor = new AdviceVisitor();
        protected readonly ILocalBuilderRepository localBuilderRepository = null;
        protected readonly AdviceDiscoveryVisitor adviceDiscoveryVistor = new AdviceDiscoveryVisitor();

        internal AbstractMethodAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings settings, bool topAspectWeaver = false) {
            var weavingSettings = settings.WeavingSettings;
            var argumentsWeavingSetings = aspectDefinition.ToArgumentsWeavingSettings(weavingSettings.MethodInfoImpl.DeclaringType);

            advices = aspectDefinition.Advices;
            this.aspectDefinition = aspectDefinition;
            aspectRepository = settings.AspectRepository;
            localBuilderRepository = new LocalBuilderRepository();

            if (topAspectWeaver) {
                var @params = weavingSettings.MethodInfoImpl.GetParameters();

                argumentsWeavingSetings.Parameters = @params.Select(@param => @param.ParameterType).ToArray();
                argumentsWeaver = new MethodImplArgumentsWeaver(argumentsWeavingSetings, settings, localBuilderRepository);
            }
            else {
                argumentsWeaver = new AspectArgumentsWeaver(argumentsWeavingSetings, settings, localBuilderRepository);
            }

            aspectDefinition.Advices.ForEach(advice => advice.Accept(adviceDiscoveryVistor));
        }

        private IAdviceExpression ResolveOnMethodEntryAdvice() {
            IAdviceDefinition selectedAdviceDefinition = null;
            Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;
            var onMethodInvokeAdvice = adviceDiscoveryVistor.OnMethodInvokeAdvice;

            adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnMethodInvokeAdvice);
            selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onMethodInvokeAdvice));

            return adviceExpressionFactory(selectedAdviceDefinition);
        }

        protected virtual Type ToImplArgumentType(Type argumentsType) {
            var genericArguments = argumentsType.GetGenericArguments();
            var genericArgumentsWithContext = new[] { aspectDefinition.AspectDeclaringType }.Concat(genericArguments);

            return argumentsType.MakeGenericArgsType(genericArgumentsWithContext.ToArray());
        }

        public abstract ILGenerator Weave(ILGenerator ilGenerator);
    }
}
