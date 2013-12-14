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
    internal class MethodInterceptionAspectWeaver : AbstractMethodAspectWeaver
    {
        private readonly BindingSettings bindingSettings = null;
        private readonly IAspcetWeaver nestedAspectWeaver = null;

        internal MethodInterceptionAspectWeaver(IAspectExpression expression, IAspectDefinition aspectDefinition, IAspectWeavingSettings settings)
            : base(expression, aspectDefinition, settings) {
            IAdviceExpression selectedExpression = null;
            var invokeWeavers = new List<IMethodScopeWeaver>();
            var aspectArgumentType = aspectDefinition.GetArgumentType();
            var genericArguments = settings.ArgumentsWeaver.ArgumentType.GetGenericArguments();
            var aspectSettings = new AdviceWeavingSettings(aspectDefinition.Aspect.AspectType, settings);

            bindingSettings = new BindingSettings { 
                ArgumentsWeaver = settings.ArgumentsWeaver, 
                WeavingSettings  = settings.WeavingSettings
            };

            if (settings.ArgumentsWeaver.IsFunction) {
                bindingSettings.BindingType = aspectArgumentType.MakeGenericFunctionBinding(genericArguments);
            }
            else {
                bindingSettings.BindingType = aspectArgumentType.MakeGenericActionBinding(genericArguments);
            }

            selectedExpression = ResolveOnMethodInvokeAdvice();
            nestedAspectWeaver = expression.Reduce(aspectSettings);
            invokeWeavers.Add(selectedExpression.Reduce(aspectSettings));

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

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            FieldInfo weavedMemeber = null;
            LocalBuilder bindingLocalBuilder = null;
            Type methodBindingWeaverBaseType = null;
            IMethodBindingWeaver bindingWeaver = null;
            var localBuilderRepository = bindingSettings.ArgumentsWeaver.LocalBuilderRepository;

            if (nestedAspectWeaver.Is<AspectDecoratorWeaver>()) {
                bindingWeaver = new MethodDecoratorBindingWeaver(bindingSettings, nestedAspectWeaver);
            }
            else {
                bindingWeaver = new OnMethodInterceptionBindingWeaver(bindingSettings, nestedAspectWeaver);
            }

            weavedMemeber = bindingWeaver.Weave();
            methodBindingWeaverBaseType = weavedMemeber.ReflectedType.GetInterfaces().First();
            bindingLocalBuilder = ilGenerator.DeclareLocal(weavedMemeber.ReflectedType);
            localBuilderRepository.Add(methodBindingWeaverBaseType, bindingLocalBuilder);
            ilGenerator.Emit(OpCodes.Ldsfld, weavedMemeber);
            ilGenerator.EmitStoreLocal(bindingLocalBuilder);
            aspectArgumentsWeaver.Weave(ilGenerator);

            return weaver.Weave(ilGenerator);
        }
    }
}
