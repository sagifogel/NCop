using NCop.Weaving.Extensions;
using System;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class NestedActionAspectArgsMappingWeaver : AbstractAspectArgsMappingWeaver
    {
        private readonly Type topAspectInScopeArgType = null;

        internal NestedActionAspectArgsMappingWeaver(Type topAspectInScopeArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsSettings argumentsSettings)
            : base(aspectWeavingSettings, argumentsSettings) {
            this.topAspectInScopeArgType = topAspectInScopeArgType;
        }

        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            var topAspectInScopeLocalBuilder = localBuilderRepository.Get(topAspectInScopeArgType);

            ilGenerator.EmitLoadLocal(topAspectInScopeLocalBuilder);
        }
    }
}
