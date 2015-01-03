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
    internal class TopSetPropertyInterceptionAspectWeaver : AbstractInterceptionAspectWeaver
    {
        protected readonly IArgumentsWeaver argumentsWeaver = null;

        internal TopSetPropertyInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeavingSettings.Parameters = new[] { aspectDefinition.Member.ReturnType };
            argumentsWeaver = new TopSetPropertyInterceptionArgumentsWeaver(aspectDefinition.Member, argumentsWeavingSettings, aspectWeavingSettings);
            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }

        protected override IAdviceExpression ResolveInterceptionAdviceExpression() {
            IAdviceDefinition selectedAdviceDefinition = null;
            var onSetPropertyAdvice = adviceDiscoveryVistor.OnSetPropertyAdvice;
            Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;

            adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnSetPropertyAdvice);
            selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onSetPropertyAdvice));

            return adviceExpressionFactory(selectedAdviceDefinition);
        }

        public override void Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);
        }
    }
}
