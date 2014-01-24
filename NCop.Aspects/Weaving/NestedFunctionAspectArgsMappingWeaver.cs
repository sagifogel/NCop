using NCop.Weaving.Extensions;
using System.Reflection.Emit;
using NCop.Core.Extensions;
using System;
using System.Linq;

namespace NCop.Aspects.Weaving
{
    internal class NestedFunctionAspectArgsMappingWeaver : AbstractAspectArgsMappingWeaver
    {
        private readonly Type previousAspectArgType = null;
        private LocalBuilder previousAspectArgsLocalBuilder = null;

        internal NestedFunctionAspectArgsMappingWeaver(Type previousAspectArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsSettings argumentsSettings)
            : base(aspectWeavingSettings, argumentsSettings) {
            this.previousAspectArgType = previousAspectArgType;
        }

        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            WeaveLoadPreviousAspectLocal(ilGenerator);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            previousAspectArgsLocalBuilder = localBuilderRepository.Get(previousAspectArgType);
            base.Weave(ilGenerator);
            
            return ilGenerator;
        }

        private void WeaveLoadPreviousAspectLocal(ILGenerator ilGenerator) {
            ilGenerator.EmitLoadLocal(previousAspectArgsLocalBuilder);
        }
    }
}