using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingGetPropertyInterceptionAspectWeaver : AbstractGetPropertyInterceptionAspectWeaver
    {
        protected readonly PropertyInfo property = null;
        protected readonly IArgumentsWeaver argumentsWeaver = null;

        internal BindingGetPropertyInterceptionAspectWeaver(IPropertyAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            IMethodScopeWeaver finallyWeaver = null;

            property = aspectDefinition.Member;
            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeavingSettings.Parameters = new[] { aspectDefinition.Member.PropertyType };
            argumentsWeaver = new BindingGetPropertyInterceptionArgumentsWeaver(aspectDefinition.Member, argumentsWeavingSettings, aspectWeavingSettings);
            finallyWeaver = new FinallyBindingPropertyAspectWeaver(aspectDefinition.Member, argumentsWeavingSettings, aspectWeavingSettings);
            weaver = new TryFinallyAspectWeaver(methodScopeWeavers, new[] { finallyWeaver });
        }

        public override void Weave(ILGenerator ilGenerator) {
            var propertyArgumentContract = property.ToPropertyArgumentContract();
            var propertyArgumentContractProperty = propertyArgumentContract.GetProperty("Value");

            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);
            ilGenerator.EmitLoadArg(2);
            ilGenerator.Emit(OpCodes.Callvirt, propertyArgumentContractProperty.GetGetMethod());
        }
    }
}
