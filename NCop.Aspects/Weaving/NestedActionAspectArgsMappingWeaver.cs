using NCop.Weaving.Extensions;
using System;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class NestedActionAspectArgsMappingWeaver : AbstractAspectArgsMappingWeaver
    {   
        private readonly Type previousAspectArgType = null;

        internal NestedActionAspectArgsMappingWeaver(Type previousAspectArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsSettings argumentsSettings)
            : base(aspectWeavingSettings, argumentsSettings) {
            this.previousAspectArgType = previousAspectArgType;
        }

        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            var previousAspectArgsLocalBuilder = localBuilderRepository.Get(previousAspectArgType);

            ilGenerator.EmitLoadLocal(previousAspectArgsLocalBuilder);
        }
    }
}
