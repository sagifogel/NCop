using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Composite.Weaving;
using NCop.Weaving.Extensions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopBindingMethodInterceptionAspectWeaver : AbstractMethodInterceptionAspectWeaver
    {
        protected readonly IArgumentsWeaver argumentsWeaver = null;

        internal TopBindingMethodInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            argumentsWeavingSetings.BindingsDependency = weavedType;
            argumentsWeaver = new TopBindingMethodInterceptionArgumentsWeaver(argumentsWeavingSetings, aspectWeavingSettings);
            methodScopeWeavers.Add(new TopAspectArgsMappingWeaverImpl(aspectWeavingSettings, argumentsWeavingSetings));
            ArgumentType = argumentsWeavingSetings.ArgumentType;
            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            var aspectArgsType = weavingSettings.MethodInfoImpl.ToAspectArgumentContract();

            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);

            if (argumentsWeavingSetings.IsFunction) {
                var returnValueProperty = aspectArgsType.GetProperty("ReturnValue");

                ilGenerator.EmitLoadArg(2);
                ilGenerator.Emit(OpCodes.Callvirt, returnValueProperty.GetGetMethod());
            }

            return ilGenerator;
        }
    }
}