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
using NCop.Aspects.Framework;
using NCop.Aspects.Engine;
using NCop.Core.Extensions;

namespace NCop.Aspects.Weaving
{
    public class MethodInterceptionAspectWeaver : AbstractMethodAspectWeaver
    {
        private readonly IMethodScopeWeaver nestedScopeWeaver = null;

        internal MethodInterceptionAspectWeaver(IAspectExpression expression, IAspectDefinition aspectDefinition, IAspectWeaverSettings settings)
            : base(expression, aspectDefinition, settings) {
            IAdviceExpression selectedExpression = null;
            var invokeWeavers = new List<IMethodScopeWeaver>();
            var localWeaver = new AspectArgsLocalWeaver(GetArgumentsType());
            var newSettings = new AspectWeaverSettings { AspectRepository = aspectRepository };

            selectedExpression = ResolveOnMethodInvokeAdvice();
            invokeWeavers.Add(selectedExpression.Reduce(localWeaver));
            nestedScopeWeaver = expression.Reduce(newSettings);
            weaver = new MethodScopeWeaversQueue(invokeWeavers);
        }

        private IAdviceExpression ResolveOnMethodInvokeAdvice() {
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
