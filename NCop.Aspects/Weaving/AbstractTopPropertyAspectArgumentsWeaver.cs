using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractTopPropertyAspectArgumentsWeaver : AbstractTopAspectArgumentsWeaver<PropertyInfo>
    {
        protected readonly FieldInfo bindingsDependency = null;

        internal AbstractTopPropertyAspectArgumentsWeaver(PropertyInfo property, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(property, argumentWeavingSettings, aspectWeavingSettings) {
            IsProperty = true;
            bindingsDependency = argumentWeavingSettings.BindingsDependency;
        }
    }
}
