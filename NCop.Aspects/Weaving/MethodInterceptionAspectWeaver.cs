using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Composite.Weaving;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public class MethodInterceptionAspectWeaver : AbstractMethodAspectWeaver
    {
        internal MethodInterceptionAspectWeaver(IAspectExpression expression, IAspectDefinition aspectDefinition)
            : base(expression, aspectDefinition) {
            IAdviceExpression selectedExpression = null;
            var invokeWeavers = new List<IMethodScopeWeaver>();
            var localWeaver = new AspectArgsLocalWeaver(null);

            selectedExpression = ResolveOnMethodEntryAdvice();
            invokeWeavers.Add(selectedExpression.Reduce(localWeaver));

            weaver = new MethodScopeWeaversQueue(invokeWeavers);
        }

        private IAdviceExpression ResolveOnMethodEntryAdvice() {
            IAdviceDefinition selectedAdviceDefinition = null;
            Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;
            var onMethodInvokeAdvice = adviceDiscoveryVistor.OnMethodInvokeAdvice;

            adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnMethodInvokeAdvice);
            selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onMethodInvokeAdvice));

            return adviceExpressionFactory(selectedAdviceDefinition);
        }

        public override ILGenerator Weave(ILGenerator iLGenerator, ITypeDefinition typeDefinition) {
            return weaver.Weave(iLGenerator, typeDefinition);
        }
    }
}
