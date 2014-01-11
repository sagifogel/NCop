using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodInterceptionAspectWeaver : AbstractMethodAspectWeaver
    {
        private readonly FieldInfo weavedType = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;

        internal NestedMethodInterceptionAspectWeaver(Type previousAspectArgType, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings) {
            var argumentWeavingSettings = aspectDefinition.ToArgumentsWeavingSettings();

            this.weavedType = weavedType;
            argumentsWeaver = new NestedMethodIntercpetionArgumentsWeaver(previousAspectArgType, aspectWeavingSettings, argumentWeavingSettings);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            var methodInoImpl = aspectWeavingSettings.WeavingSettings.MethodInfoImpl;

            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, methodInoImpl);

            return ilGenerator;
        }
    }
}
