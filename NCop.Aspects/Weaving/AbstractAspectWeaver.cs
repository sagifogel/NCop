using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractAspectWeaver : IAspectTypeReflectorWeaver
    {
        protected IMethodScopeWeaver weaver = null;
        protected readonly BindingSettings bindingSettings = null;
        protected readonly IWeavingSettings weavingSettings = null;
        protected List<IMethodScopeWeaver> methodScopeWeavers = null;
        protected readonly IAspectRepository aspectRepository = null;
        protected readonly IAdviceDefinitionCollection advices = null;
        protected readonly IAspectDefinition aspectDefinition = null;
        protected ArgumentsWeavingSettings argumentsWeavingSettings = null;
        protected readonly AdviceVisitor adviceVisitor = new AdviceVisitor();
        protected readonly IAspectWeavingSettings aspectWeavingSettings = null;
        protected readonly AdviceDiscoveryVisitor adviceDiscoveryVistor = new AdviceDiscoveryVisitor();

        internal AbstractAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings) {
            advices = aspectDefinition.Advices;
            this.aspectDefinition = aspectDefinition;
            this.aspectWeavingSettings = aspectWeavingSettings;
            bindingSettings = aspectDefinition.ToBindingSettings();
            weavingSettings = aspectWeavingSettings.WeavingSettings;
            aspectRepository = aspectWeavingSettings.AspectRepository;
            argumentsWeavingSettings = aspectDefinition.ToArgumentsWeavingSettings();
            aspectDefinition.Advices.ForEach(advice => advice.Accept(adviceDiscoveryVistor));
        }

        public Type ArgumentType { get; protected set; }

        public abstract void Weave(ILGenerator ilGenerator);
    }
}
