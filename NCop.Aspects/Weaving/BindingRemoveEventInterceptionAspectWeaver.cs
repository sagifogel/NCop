using NCop.Aspects.Aspects;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class BindingRemoveEventInterceptionAspectWeaver : AbstractRemoveEventInterceptionAspectWeaver
    {
        internal BindingRemoveEventInterceptionAspectWeaver(IEventAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeavingSettings.Parameters = new[] { aspectDefinition.Member.EventHandlerType };
            argumentsWeaver = new BindingEventInterceptionArgumentsWeaver(aspectDefinition, argumentsWeavingSettings, aspectWeavingSettings, bindingSettings);
            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }
    }
}