using NCop.Weaving.Extensions;
using System.Reflection.Emit;
using NCop.Core.Extensions;
using System;
using System.Linq;

namespace NCop.Aspects.Weaving
{
    internal class NestedFunctionAspectArgsMappingWeaver : AbstractAspectArgsMappingWeaver
    {
        private readonly Type topAspectInScopeArgType = null;
        private LocalBuilder topAspectInScopeArgsLocalBuilder = null;

        internal NestedFunctionAspectArgsMappingWeaver(Type topAspectInScopeArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsSettings argumentsSettings)
            : base(aspectWeavingSettings, argumentsSettings) {
            this.topAspectInScopeArgType = topAspectInScopeArgType;
        }

        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            WeaveLoadPreviousAspectLocal(ilGenerator);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            topAspectInScopeArgsLocalBuilder = localBuilderRepository.Get(topAspectInScopeArgType);
            
            return base.Weave(ilGenerator);
        }

        private void WeaveLoadPreviousAspectLocal(ILGenerator ilGenerator) {
            ilGenerator.EmitLoadLocal(topAspectInScopeArgsLocalBuilder);
        }
    }
}