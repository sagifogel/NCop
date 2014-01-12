using NCop.Weaving.Extensions;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class ActionAspectArgsMappingWeaver : AbstractAspectArgsMappingWeaver
    {
        internal ActionAspectArgsMappingWeaver(IAspectWeavingSettings aspectWeavingSettings, IArgumentsSettings argumentsSettings)
            : base(aspectWeavingSettings, argumentsSettings) {
        }

        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            ilGenerator.EmitLoadArg(2);
        }
    }
}
