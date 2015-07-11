using NCop.Aspects.Aspects;
using System.Reflection;
using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
    internal class BindingAddEventInterceptionAspectWeaver : AbstractAddEventInterceptionAspectWeaver
    {
        internal BindingAddEventInterceptionAspectWeaver(IEventAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeavingSettings.Parameters = new[] { aspectDefinition.Member.EventHandlerType };
            argumentsWeaver = new BindingEventInterceptionArgumentsWeaver(aspectDefinition, argumentsWeavingSettings, aspectWeavingSettings);
            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }
    }
}
