using NCop.Aspects.Aspects;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{   
    internal class TopRemoveEventInterceptionAspectWeaver : AbstractRemoveEventInterceptionAspectWeaver
    {
        internal TopRemoveEventInterceptionAspectWeaver(IEventAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            argumentsWeaver = new TopEventInterceptionArgumentsWeaver(aspectDefinition, argumentsWeavingSettings, aspectWeavingSettings);
            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }
    }
}
