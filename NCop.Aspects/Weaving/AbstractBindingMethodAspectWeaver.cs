using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractBindingMethodAspectWeaver : IBindingTypeReflector
    {
        protected readonly BindingSettings bindingSettings = null;
        protected readonly IAspectDefinition aspectDefinition = null;

        internal AbstractBindingMethodAspectWeaver(IAspectDefinition aspectDefinition) {
            this.aspectDefinition = aspectDefinition;
            bindingSettings = aspectDefinition.ToBindingSettings();
        }

        public virtual FieldInfo WeavedType { get; private set; }
    }
}
