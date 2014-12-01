using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractTopAspectPropertyArgumentsWeaver : AbstractArgumentsWeaver, IAspectArgumentsWeaver
    {
        internal AbstractTopAspectPropertyArgumentsWeaver(IArgumentsWeavingSettings argumentWeavingSettings, IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            var localBuilder = BuildArguments(ilGenerator, Parameters);

            LocalBuilderRepository.Add(localBuilder);
        }

        public abstract LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters);
	}
}