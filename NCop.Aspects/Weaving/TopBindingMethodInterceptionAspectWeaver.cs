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

        internal TopBindingMethodInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectMethodWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeaver = new TopBindingMethodInterceptionArgumentsWeaver(argumentsWeavingSettings, aspectWeavingSettings);
            methodScopeWeavers.Add(new TopAspectArgsMappingWeaverImpl(aspectWeavingSettings, argumentsWeavingSettings));
            ArgumentType = argumentsWeavingSettings.ArgumentType;
            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            var aspectArgsType = weavingSettings.MethodInfoImpl.ToAspectArgumentContract();

            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);

            if (argumentsWeavingSettings.IsFunction) {
                var returnValueProperty = aspectArgsType.GetProperty("ReturnValue");

                ilGenerator.EmitLoadArg(2);
                ilGenerator.Emit(OpCodes.Callvirt, returnValueProperty.GetGetMethod());
            }

            return ilGenerator;
        }
    }
}