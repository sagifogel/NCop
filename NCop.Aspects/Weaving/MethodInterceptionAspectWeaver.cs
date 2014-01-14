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
    internal class MethodInterceptionAspectWeaver : AbstractMethodInterceptionAspectWeaver
    {
		protected readonly IArgumentsWeaver argumentsWeaver = null;

		internal MethodInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            WeavedType = weavedType;
            argumentsWeavingSetings.BindingsDependency = weavedType;
            argumentsWeaver = new AspectArgumentsWeaver(argumentsWeavingSetings, aspectWeavingSettings);

            if (argumentsWeavingSetings.IsFunction) {
                methodScopeWeavers.Add(new FunctionAspectArgsMappingWeaver(aspectWeavingSettings, argumentsWeavingSetings));
            }
            else {
                methodScopeWeavers.Add(new ActionAspectArgsMappingWeaver(aspectWeavingSettings, argumentsWeavingSetings));
            }

            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            var weavedTypeLocal = ilGenerator.DeclareLocal(WeavedType.FieldType);

            localBuilderRepository.Add(weavedTypeLocal);
            argumentsWeaver.Weave(ilGenerator);
            
            return weaver.Weave(ilGenerator);
        }
    }
}
