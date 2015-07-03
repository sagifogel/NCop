using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopAddEventInterceptionAspectWeaver : AbstractTopEventFragmentInterceptionAspectWeaver
    {
        internal TopAddEventInterceptionAspectWeaver(IEventAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
        }

        protected override IAdviceExpression ResolveInterceptionAdviceExpression() {
            IAdviceDefinition selectedAdviceDefinition = null;
            var onAddHandlerAdvice = adviceDiscoveryVistor.OnAddHandlerAdvice;
            Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;

            adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnAddHandlerAdvice);
            selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onAddHandlerAdvice));

            return adviceExpressionFactory(selectedAdviceDefinition);
        }

        public override void Weave(ILGenerator ilGenerator) {
            LocalBuilder aspectArgLocalBuilder = null;
            var argumentType = argumentsWeavingSettings.ArgumentType;
            var valueProperty = argumentType.GetProperty("Value");

            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);
            aspectArgLocalBuilder = localBuilderRepository.Get(argumentType);
            ilGenerator.EmitLoadLocal(aspectArgLocalBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, valueProperty.GetGetMethod());
        }
    }
}
