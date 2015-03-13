using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Weaving;
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
            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeaver = new TopBindingMethodInterceptionArgumentsWeaver(aspectDefinition.Method, argumentsWeavingSettings, aspectWeavingSettings);
            methodScopeWeavers.Add(new TopAspectArgsMappingWeaverImpl(aspectWeavingSettings, argumentsWeavingSettings));
            ArgumentType = argumentsWeavingSettings.ArgumentType;
            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }

        public override void Weave(ILGenerator ilGenerator) {
            var aspectArgsType = aspectMethodDefinition.Method.ToAspectArgumentContract();

            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);

            if (argumentsWeavingSettings.IsFunction) {
                var returnValueProperty = aspectArgsType.GetProperty("ReturnValue");

                ilGenerator.EmitLoadArg(2);
                ilGenerator.Emit(OpCodes.Callvirt, returnValueProperty.GetGetMethod());
            }
        }
    }
}