using NCop.Aspects.Aspects;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopAddEventInterceptionAspectWeaver : AbstractAddEventInterceptionAspectWeaver
    {
        internal TopAddEventInterceptionAspectWeaver(IEventAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeavingSettings.Parameters = new[] { aspectDefinition.Member.EventHandlerType };
            argumentsWeaver = new TopEventInterceptionArgumentsWeaver(aspectDefinition, argumentsWeavingSettings, aspectWeavingSettings);
            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }
    }
}
