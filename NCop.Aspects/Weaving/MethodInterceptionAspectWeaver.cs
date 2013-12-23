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
    internal class MethodInterceptionAspectWeaver : AbstractMethodAspectWeaver, IWithFieldAspectWeaver
    {
		internal MethodInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings settings, FieldInfo weavedType, bool topAspectWeaver = false)
			: base(aspectDefinition, settings, topAspectWeaver) {
            IAdviceExpression selectedExpression = null;
            var invokeWeavers = new List<IMethodScopeWeaver>();
            var argumentsWeavingSettings = aspectDefinition.ToArgumentsWeavingSettings(settings.WeavingSettings.MethodInfoImpl.DeclaringType);
            var aspectSettings = new AdviceWeavingSettings(aspectDefinition.Aspect.AspectType, settings, localBuilderRepository, argumentsWeavingSettings);

            WeavedType = weavedType;
            selectedExpression = ResolveOnMethodInvokeAdvice();
            invokeWeavers.Add(selectedExpression.Reduce(aspectSettings));
            weaver = new MethodScopeWeaversQueue(invokeWeavers);
        }

        public FieldInfo WeavedType { get; protected set; }

        private IAdviceExpression ResolveOnMethodInvokeAdvice() {
            IAdviceDefinition selectedAdviceDefinition = null;
            Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;
            var onMethodInvokeAdvice = adviceDiscoveryVistor.OnMethodInvokeAdvice;

            adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnMethodInvokeAdvice);
            selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onMethodInvokeAdvice));

            return adviceExpressionFactory(selectedAdviceDefinition);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            LocalBuilder bindingLocalBuilder = null;
            Type methodBindingWeaverBaseType = null;
            
            methodBindingWeaverBaseType = WeavedType.ReflectedType.GetInterfaces().First();
			bindingLocalBuilder = ilGenerator.DeclareLocal(WeavedType.ReflectedType);
            localBuilderRepository.Add(methodBindingWeaverBaseType, bindingLocalBuilder);
			ilGenerator.Emit(OpCodes.Ldsfld, WeavedType);
            ilGenerator.EmitStoreLocal(bindingLocalBuilder);
            argumentsWeaver.Weave(ilGenerator);

            return weaver.Weave(ilGenerator);
        }
    }
}
