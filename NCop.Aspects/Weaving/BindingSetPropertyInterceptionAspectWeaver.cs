using NCop.Aspects.Aspects;
using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingSetPropertyInterceptionAspectWeaver : AbstractSetPropertyInterceptionAspectWeaver
    {
        protected readonly IArgumentsWeaver argumentsWeaver = null;

        internal BindingSetPropertyInterceptionAspectWeaver(IPropertyAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            var method = aspectDefinition.Property.GetSetMethod();

            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeavingSettings.Parameters = new[] { aspectDefinition.Property.PropertyType };
            argumentsWeaver = new BindingSetPropertyInterceptionArgumentsWeaver(method, argumentsWeavingSettings, aspectWeavingSettings);
            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }

        public override void Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);
        }
    }
}
