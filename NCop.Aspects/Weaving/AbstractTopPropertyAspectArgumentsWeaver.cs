using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractTopPropertyAspectArgumentsWeaver : AbstractTopAspectArgumentsWeaver
    {
        protected readonly FieldInfo bindingsDependency = null;

        internal AbstractTopPropertyAspectArgumentsWeaver(MethodInfo method, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, argumentWeavingSettings, aspectWeavingSettings) {
            IsProperty = true;
            bindingsDependency = argumentWeavingSettings.BindingsDependency;
        }
    }
}
