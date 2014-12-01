using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Extensions;
using System.Reflection.Emit;
using System.Reflection;
using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractTopAspectArgumentsWeaver : AbstractArgumentsWeaver, IAspectArgumentsWeaver
    {
        internal AbstractTopAspectArgumentsWeaver(IArgumentsWeavingSettings argumentWeavingSettings, IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            var localBuilder = BuildArguments(ilGenerator);

            LocalBuilderRepository.Add(localBuilder);
        }

        public abstract LocalBuilder BuildArguments(ILGenerator ilGenerator);
    }
}
