using System;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractTopAspectMethodArgumentsWeaver: AbstractArgumentsWeaver, IAspectArgumentsWeaver
    {
        internal AbstractTopAspectMethodArgumentsWeaver(IArgumentsWeavingSettings argumentWeavingSettings, IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            var localBuilder = BuildArguments(ilGenerator, Parameters);

            LocalBuilderRepository.Add(localBuilder);
        }

        public abstract LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters);
	}
}
