using NCop.Weaving.Extensions;
using System;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class AspectArgsMappingWeaverImpl : AbstractAspectArgsMappingWeaver
    {
        protected readonly Type topAspectInScopeArgType = null;

        internal AspectArgsMappingWeaverImpl(Type topAspectInScopeArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsSettings argumentsSettings)
            : base(aspectWeavingSettings, argumentsSettings) {
            this.topAspectInScopeArgType = topAspectInScopeArgType;
        }

        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            var localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            var topAspectInScopeArgTypeLocalBuilder = localBuilderRepository.Get(topAspectInScopeArgType);

            ilGenerator.EmitLoadLocal(topAspectInScopeArgTypeLocalBuilder);
        }
    }
}
