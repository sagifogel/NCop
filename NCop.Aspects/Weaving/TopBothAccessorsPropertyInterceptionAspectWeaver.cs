using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using NCop.Composite.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopBothAccessorsPropertyInterceptionAspectWeaver : AbstractMethodInterceptionAspectWeaver
    {
        protected readonly IArgumentsWeaver argumentsWeaver = null;

        internal TopBothAccessorsPropertyInterceptionAspectWeaver(IPropertyAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(null, aspectWeavingSettings, weavedType) {
            var method = aspectDefinition.Property.GetSetMethod();

            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeavingSettings.Parameters = new[] { aspectDefinition.Property.PropertyType };
            argumentsWeaver = new TopGetPropertyInterceptionArgumentsWeaver(method, argumentsWeavingSettings, aspectWeavingSettings);
            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }

        protected override IAdviceExpression ResolveInterceptionAdviceExpression() {
            IAdviceDefinition selectedAdviceDefinition = null;
            var onGetPropertyAdvice = adviceDiscoveryVistor.OnGetPropertyAdvice;
            Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;

            adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnGetPropertyAdvice);
            selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onGetPropertyAdvice));

            return adviceExpressionFactory(selectedAdviceDefinition);
        }

        public override void Weave(ILGenerator ilGenerator) {
            LocalBuilder argsLocalBuilder = null;
            var aspectArgsType = aspectMethodDefinition.Method.ToPropertyAspectArgument();

            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);
            argsLocalBuilder = localBuilderRepository.Get(argumentsWeavingSettings.ArgumentType);
            ilGenerator.EmitLoadLocal(argsLocalBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, aspectArgsType.GetProperty("Value").GetGetMethod());
        }
    }
}
