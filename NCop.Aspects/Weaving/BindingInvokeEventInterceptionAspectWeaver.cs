using NCop.Aspects.Aspects;
using System.Reflection;
using NCop.Core.Extensions;
using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
    internal class BindingInvokeEventInterceptionAspectWeaver : AbstractInvokeEventInterceptionAspectWeaver
    {
        internal BindingInvokeEventInterceptionAspectWeaver(IEventAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeavingSettings.Parameters = new[] { aspectDefinition.Member.EventHandlerType };
            argumentsWeaver = new BindingEventInterceptionArgumentsWeaver(aspectDefinition, argumentsWeavingSettings, aspectWeavingSettings);

            if (aspectDefinition.Member.IsFunction()) {
                methodScopeWeavers.Add(new TopGetReturnValueWeaver(aspectWeavingSettings, argumentsWeavingSettings));
            }

            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }
    }
}
