using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class NestedAspectDecoratorWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        private readonly IArgumentsWeaver argumentsWeaver = null;

        internal NestedAspectDecoratorWeaver(IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            argumentsWeaver = new NestedMethodDecoratorArgumentsWeaver(argumentWeavingSettings);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfoImpl);

            return ilGenerator;
        }
    }
}
