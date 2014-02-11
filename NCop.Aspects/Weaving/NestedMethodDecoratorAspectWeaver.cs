using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodDecoratorAspectWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        private readonly Type previousAspectArgType = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;
        private readonly IByRefArgumentsStoreWeaver byRefArgumentStoreWeaver = null;

        internal NestedMethodDecoratorAspectWeaver(Type previousAspectArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            this.previousAspectArgType = previousAspectArgType;
            this.argumentsWeavingSettings = argumentsWeavingSettings;
            byRefArgumentStoreWeaver = aspectWeavingSettings.ByRefArgumentsStoreWeaver;
            argumentsWeaver = new NestedMethodDecoratorArgumentsWeaver(previousAspectArgType, aspectWeavingSettings, argumentsWeavingSettings);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            byRefArgumentStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfoImpl);
            byRefArgumentStoreWeaver.RestoreArgsIfNeeded(ilGenerator);

            if (argumentsWeavingSettings.IsFunction) {
                var setReturnValueWeaver = new SetReturnValueWeaver(previousAspectArgType);

                setReturnValueWeaver.Weave(ilGenerator);
            }

            return ilGenerator;
        }
    }
}
