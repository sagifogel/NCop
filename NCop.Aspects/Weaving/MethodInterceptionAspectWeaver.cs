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
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving
{
    public class MethodInterceptionAspectWeaver : AbstractMethodAspectWeaver
    {
        private readonly IMethodScopeWeaver nestedScopeWeaver = null;
        private readonly OnMethodInvokeBindingWeaver bindingWeaver = null;

        internal MethodInterceptionAspectWeaver(IAspectExpression expression, IAspectDefinition aspectDefinition, IAspectWeaverSettings settings)
            : base(expression, aspectDefinition, settings) {
            Type genericMethodBinding = null;
            var argumentType = GetArgumentType();
            IAdviceExpression selectedExpression = null;
            var argumentTypes = MakeGenericArgumentType(argumentType);
            var invokeWeavers = new List<IMethodScopeWeaver>();
            var localWeaver = new AspectArgsLocalWeaver(argumentTypes);
            var newSettings = new AspectWeaverSettings { AspectRepository = aspectRepository };
            var genericArguments = argumentTypes.GetGenericArguments();

            if (argumentType.IsFunctionAspectArgs()) {
                genericMethodBinding = argumentType.MakeGenericFunctionBinding(genericArguments);
            }
            else {
                genericMethodBinding = argumentType.MakeGenericActionBinding(genericArguments);
            }

            selectedExpression = ResolveOnMethodInvokeAdvice();
            nestedScopeWeaver = expression.Reduce(newSettings);
            bindingWeaver = new OnMethodInvokeBindingWeaver(genericMethodBinding, nestedScopeWeaver);
            invokeWeavers.Add(selectedExpression.Reduce(localWeaver));

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
