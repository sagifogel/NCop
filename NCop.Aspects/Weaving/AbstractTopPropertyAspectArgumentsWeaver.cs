using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractTopPropertyAspectArgumentsWeaver : AbstractTopAspectArgumentsWeaver
    {
        internal AbstractTopPropertyAspectArgumentsWeaver(MethodInfo methodInfo, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(methodInfo, argumentWeavingSettings, aspectWeavingSettings) {
            IsProperty = true;
        }
    }
}
