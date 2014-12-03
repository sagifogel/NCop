using System;
using System.Linq;
using System.Reflection.Emit;
using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Aspects.Extensions;
using System.Collections.Generic;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractMethodAspectWeaver : IAspectTypeReflectorWeaver
    {
        protected IMethodScopeWeaver weaver = null;
        protected List<IMethodScopeWeaver> methodScopeWeavers = null;
        protected readonly IAspectRepository aspectRepository = null;
        protected readonly IAspectDefinition aspectDefinition = null;
        protected readonly IAdviceDefinitionCollection advices = null;
		protected readonly IMethodWeavingSettings weavingSettings = null;
		protected readonly AdviceVisitor adviceVisitor = new AdviceVisitor();
        protected readonly IAspectMethodWeavingSettings aspectWeavingSettings = null;
        protected readonly ArgumentsWeavingSettings argumentsWeavingSetings = null;
        protected readonly AdviceDiscoveryVisitor adviceDiscoveryVistor = new AdviceDiscoveryVisitor();

        internal AbstractMethodAspectWeaver(IAspectDefinition aspectDefinition, IAspectMethodWeavingSettings aspectWeavingSettings) {
            advices = aspectDefinition.Advices;
            this.aspectDefinition = aspectDefinition;
            this.aspectWeavingSettings = aspectWeavingSettings;
            weavingSettings = aspectWeavingSettings.WeavingSettings;
            aspectRepository = aspectWeavingSettings.AspectRepository;
            argumentsWeavingSetings = aspectDefinition.ToArgumentsWeavingSettings();
            aspectDefinition.Advices.ForEach(advice => advice.Accept(adviceDiscoveryVistor));
        }

        public Type ArgumentType { get; protected set; }

        public abstract ILGenerator Weave(ILGenerator ilGenerator);
    }
}
