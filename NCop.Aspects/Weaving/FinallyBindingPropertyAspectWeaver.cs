using NCop.Aspects.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class FinallyBindingPropertyAspectWeaver : IMethodScopeWeaver
    {
        private readonly MethodInfo method = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal FinallyBindingPropertyAspectWeaver(MethodInfo method, IArgumentsWeavingSettings argumentsWeavingSettings, IAspectWeavingSettings aspectWeavingSettings) {
            this.method = method;
            this.aspectWeavingSettings = aspectWeavingSettings;
            this.argumentsWeavingSettings = argumentsWeavingSettings;
        }

        public void Weave(ILGenerator ilGenerator) {
            LocalBuilder aspectArgLocalBuilder = null;
            var argumentType = argumentsWeavingSettings.ArgumentType;
            var propertyAspectArgument = method.ToPropertyAspectArgument();
            var propertyArgumentContract = method.ToPropertyArgumentContract();
            var localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            var propertyAspectArgumentProperty = propertyAspectArgument.GetProperty("Value");
            var propertyArgumentContractProperty = propertyArgumentContract.GetProperty("Value");

            ilGenerator.EmitLoadArg(2);
            aspectArgLocalBuilder = localBuilderRepository.Get(argumentType);
            ilGenerator.EmitLoadLocal(aspectArgLocalBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, propertyAspectArgumentProperty.GetGetMethod());
            ilGenerator.Emit(OpCodes.Callvirt, propertyArgumentContractProperty.GetSetMethod());
        }
    }
}
