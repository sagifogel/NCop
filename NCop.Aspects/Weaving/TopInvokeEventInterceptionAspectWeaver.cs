using NCop.Aspects.Aspects;
using NCop.Core.Extensions;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class TopInvokeEventInterceptionAspectWeaver : AbstractInvokeEventInterceptionAspectWeaver
    {
        internal TopInvokeEventInterceptionAspectWeaver(IEventAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeavingSettings.Parameters = new[] { aspectDefinition.Member.EventHandlerType };
            argumentsWeaver = new TopEventInterceptionArgumentsWeaver(aspectDefinition, argumentsWeavingSettings, aspectWeavingSettings);

            if (aspectDefinition.Member.IsFunction()) {
                methodScopeWeavers.Add(new TopGetReturnValueWeaver(aspectWeavingSettings, argumentsWeavingSettings));
            }

            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }
    }
}
