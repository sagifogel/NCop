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

		internal MethodInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings settings, FieldInfo weavedType)
            : base(aspectDefinition, settings, weavedType) {
            argumentsWeavingSetings.BindingsDependency = weavedType;
            argumentsWeaver = new AspectArgumentsWeaver(argumentsWeavingSetings, settings);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            LocalBuilder argsImplLocalBuilder = null;
            var aspectType = aspectDefinition.Aspect.AspectType;
            var aspectField = aspectRepository.GetAspectFieldByType(aspectType);

            argumentsWeaver.Weave(ilGenerator);
			argsImplLocalBuilder = localBuilderRepository.Get(argumentsWeavingSetings.ArgumentType);
            ilGenerator.Emit(OpCodes.Ldsfld, aspectField);
            ilGenerator.EmitStoreLocal(argsImplLocalBuilder);

            return weaver.Weave(ilGenerator);
        }
    }
}
