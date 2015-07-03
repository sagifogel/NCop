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

            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeavingSettings.Parameters = new[] { aspectDefinition.Member.PropertyType };
            finallyWeaver = new FinallyBindingPropertyAspectWeaver(aspectDefinition.Member, argumentsWeavingSettings, aspectWeavingSettings);
            argumentsWeaver = new BindingSetPropertyInterceptionArgumentsWeaver(aspectDefinition.Member, argumentsWeavingSettings, aspectWeavingSettings);
            weaver = new TryFinallyAspectWeaver(methodScopeWeavers, new[] { finallyWeaver });
        }

        public override void Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);
        }
    }
}
