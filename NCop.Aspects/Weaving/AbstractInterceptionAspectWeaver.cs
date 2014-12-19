using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System.Collections.Generic;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractInterceptionAspectWeaver : AbstractMethodAspectWeaver
    {
        protected readonly FieldInfo bindingDependency = null;
        protected readonly ILocalBuilderRepository localBuilderRepository = null;

        internal AbstractInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectMethodWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
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

        protected abstract IAdviceExpression ResolveInterceptionAdviceExpression();
    }
}
