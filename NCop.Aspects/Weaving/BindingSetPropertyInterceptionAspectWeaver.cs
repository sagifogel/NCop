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
            IMethodScopeWeaver finallyWeaver = null;
            var method = aspectDefinition.Method;

            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeavingSettings.Parameters = new[] { aspectDefinition.Property.PropertyType };
            finallyWeaver = new FinallyBindingPropertyAspectWeaver(method, argumentsWeavingSettings, aspectWeavingSettings);
            argumentsWeaver = new BindingSetPropertyInterceptionArgumentsWeaver(method, argumentsWeavingSettings, aspectWeavingSettings);
            weaver = new TryFinallyAspectWeaver(methodScopeWeavers, new[] { finallyWeaver });
        }

        public override void Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);
        }
    }
}
