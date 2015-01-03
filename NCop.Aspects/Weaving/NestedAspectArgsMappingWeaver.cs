using NCop.Weaving.Extensions;
using System.Reflection.Emit;
using NCop.Core.Extensions;
using System;
using System.Linq;

namespace NCop.Aspects.Weaving
{
    internal class NestedAspectArgsMappingWeaver : AbstractAspectArgsMappingWeaver
    {
        private readonly Type topAspectInScopeArgType = null;

        internal NestedAspectArgsMappingWeaver(Type topAspectInScopeArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsSettings argumentsSettings)
            : base(aspectWeavingSettings, argumentsSettings) {
            this.topAspectInScopeArgType = topAspectInScopeArgType;
        }
        
        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            var topAspectInScopeLocalBuilder = localBuilderRepository.Get(topAspectInScopeArgType);

            ilGenerator.EmitLoadLocal(topAspectInScopeLocalBuilder);
        }
    }
}