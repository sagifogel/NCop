using NCop.Aspects.Aspects;
using System.Reflection;
using System.Reflection.Emit;
using NCop.Aspects.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;

namespace NCop.Aspects.Weaving
{
    internal class BindingGetPropertyInterceptionAspectWeaver : AbstractGetPropertyInterceptionAspectWeaver
    {
        protected readonly MethodInfo method = null;
        protected readonly IArgumentsWeaver argumentsWeaver = null;

        internal BindingGetPropertyInterceptionAspectWeaver(IPropertyAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            IMethodScopeWeaver finallyWeaver = null;

            method = aspectDefinition.Property.GetSetMethod();
            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeavingSettings.Parameters = new[] { aspectDefinition.Property.PropertyType };
            argumentsWeaver = new BindingGetPropertyInterceptionArgumentsWeaver(method, argumentsWeavingSettings, aspectWeavingSettings);
            finallyWeaver = new FinallyBindingPropertyAspectWeaver(method, argumentsWeavingSettings, aspectWeavingSettings);
            weaver = new TryFinallyAspectWeaver(methodScopeWeavers, new[] { finallyWeaver });
        }

        public override void Weave(ILGenerator ilGenerator) {
            var propertyArgumentContract = method.ToPropertyArgumentContract();
            var propertyArgumentContractProperty = propertyArgumentContract.GetProperty("Value");

            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);
            ilGenerator.EmitLoadArg(2);
            ilGenerator.Emit(OpCodes.Callvirt, propertyArgumentContractProperty.GetGetMethod());
        }
    }
}
