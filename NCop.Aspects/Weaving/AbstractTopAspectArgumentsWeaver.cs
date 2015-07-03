using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractTopAspectArgumentsWeaver<TMember> : AbstractArgumentsWeaver<TMember>, IAspectArgumentsWeaver where TMember : MemberInfo
    {
        internal AbstractTopAspectArgumentsWeaver(TMember member, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(member, argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            var localBuilder = BuildArguments(ilGenerator);

            LocalBuilderRepository.Add(localBuilder);
        }

        public abstract LocalBuilder BuildArguments(ILGenerator ilGenerator);
    }
}
