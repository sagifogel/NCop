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
        private readonly OnMethodInterceptionBindingWeaver bindingWeaver = null;

        internal MethodInterceptionAspectWeaver(IAspectExpression expression, IAspectDefinition aspectDefinition, IAspectWeaverSettings settings)
            : base(expression, aspectDefinition, settings) {
            var argumentType = GetArgumentType();
            IAdviceExpression selectedExpression = null;
            var invokeWeavers = new List<IMethodScopeWeaver>();
            var argumentTypes = MakeGenericArgumentType(argumentType);
            var argsWeaver = new AspectArgsLocalWeaver(argumentTypes);
            var genericArguments = argumentTypes.GetGenericArguments();
            var aspectSettings = new AspectWeaverSettings { AspectRepository = aspectRepository };
            var bindingSettings = new BindingSettings { ArgumentsWeaver = argsWeaver };

            if (argumentType.IsFunctionAspectArgs()) {
                bindingSettings.IsFunction = true;
                bindingSettings.BindingType = argumentType.MakeGenericFunctionBinding(genericArguments);
            }
            else {
                bindingSettings.BindingType = argumentType.MakeGenericActionBinding(genericArguments);
            }

            selectedExpression = ResolveOnMethodInvokeAdvice();
            nestedScopeWeaver = expression.Reduce(aspectSettings);
            bindingWeaver = new OnMethodInterceptionBindingWeaver(bindingSettings, nestedScopeWeaver);
            invokeWeavers.Add(selectedExpression.Reduce(argsWeaver));

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

        public override ILGenerator Weave(ILGenerator iLGenerator) {
            var member = bindingWeaver.Weave();

            return weaver.Weave(iLGenerator);
        }
    }
}
