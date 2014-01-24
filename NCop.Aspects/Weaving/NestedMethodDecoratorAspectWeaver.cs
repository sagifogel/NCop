using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodDecoratorAspectWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        private readonly Type previousAspectArgType = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal NestedMethodDecoratorAspectWeaver(Type previousAspectArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            this.previousAspectArgType = previousAspectArgType;
            this.argumentsWeavingSettings = argumentsWeavingSettings;
            argumentsWeaver = new NestedMethodDecoratorArgumentsWeaver(previousAspectArgType, aspectWeavingSettings, argumentsWeavingSettings);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfoImpl);

            if (argumentsWeavingSettings.IsFunction) {
                var setReturnValueWeaver = new SetReturnValueWeaver(previousAspectArgType);

                setReturnValueWeaver.Weave(ilGenerator);
            }

            return ilGenerator;
        }
    }
}
