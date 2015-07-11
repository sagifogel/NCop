using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractInterceptionAspectWeaver : AbstractAspectWeaver
    {
        protected IArgumentsWeaver argumentsWeaver = null;
        protected readonly FieldInfo bindingDependency = null;
        protected readonly ILocalBuilderRepository localBuilderRepository = null;

        internal AbstractInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings) {
            IAdviceExpression selectedExpression = null;
            AdviceWeavingSettings adviceWeavingSettings = null;

            bindingDependency = weavedType;
            argumentsWeavingSettings = aspectDefinition.ToArgumentsWeavingSettings();
            adviceWeavingSettings = new AdviceWeavingSettings(aspectWeavingSettings, argumentsWeavingSettings);
            selectedExpression = ResolveInterceptionAdviceExpression();
            methodScopeWeavers = new List<IMethodScopeWeaver> {
                selectedExpression.Reduce(adviceWeavingSettings)
            };

            localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
        }

        public override void Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);
        }

        protected abstract IAdviceExpression ResolveInterceptionAdviceExpression();
    }
}
