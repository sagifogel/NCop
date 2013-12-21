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
        private readonly BindingSettings bindingSettings = null;
        private readonly IAspectWeaver nestedAspectWeaver = null;

        internal MethodInterceptionAspectWeaver(IAspectWeaver nestedWeaver, IAspectDefinition aspectDefinition, BindingSettings settings, FieldInfo weavedType)
            : base(nestedWeaver, aspectDefinition, settings) {
            IAdviceExpression selectedExpression = null;
            var invokeWeavers = new List<IMethodScopeWeaver>();
            var aspectSettings = new AdviceWeavingSettings(aspectDefinition.Aspect.AspectType, settings);

            bindingSettings = new BindingSettings {
                AspectArgsMapper = settings.AspectArgsMapper,
            };

            WeavedType = weavedType;
            nestedAspectWeaver = nestedWeaver;
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
            FieldInfo weavedMemeber = null;
            LocalBuilder bindingLocalBuilder = null;
            Type methodBindingWeaverBaseType = null;
            var localBuilderRepository = bindingSettings.ArgumentsWeaver.LocalBuilderRepository;
            
            methodBindingWeaverBaseType = WeavedType.ReflectedType.GetInterfaces().First();
            bindingLocalBuilder = ilGenerator.DeclareLocal(weavedMemeber.ReflectedType);
            localBuilderRepository.Add(methodBindingWeaverBaseType, bindingLocalBuilder);
            ilGenerator.Emit(OpCodes.Ldsfld, weavedMemeber);
            ilGenerator.EmitStoreLocal(bindingLocalBuilder);
            aspectArgumentsWeaver.Weave(ilGenerator);

            return weaver.Weave(ilGenerator);
        }
    }
}
