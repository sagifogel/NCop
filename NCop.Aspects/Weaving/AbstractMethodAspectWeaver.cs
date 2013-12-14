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
    internal abstract class AbstractMethodAspectWeaver : IAspcetWeaver
    {
        protected IMethodScopeWeaver weaver = null;
        protected readonly IAspectRepository aspectRepository = null;
        protected readonly IAspectDefinition aspectDefinition = null;
        protected readonly IAdviceDefinitionCollection advices = null;
        protected readonly AdviceVisitor adviceVisitor = new AdviceVisitor();
        protected readonly IArgumentsWeaver aspectArgumentsWeaver = null;
        protected readonly AdviceDiscoveryVisitor adviceDiscoveryVistor = new AdviceDiscoveryVisitor();

        internal AbstractMethodAspectWeaver(IAspectExpression expression, IAspectDefinition aspectDefinition, IAspectWeavingSettings settings) {
            advices = aspectDefinition.Advices;
            this.aspectRepository = settings.AspectRepository;
            this.aspectArgumentsWeaver = settings.ArgumentsWeaver;
            aspectDefinition.Advices.ForEach(advice => advice.Accept(adviceDiscoveryVistor));
            this.aspectDefinition = aspectDefinition;
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
