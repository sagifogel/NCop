using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractBindingMethodAspectWeaver : IBindingTypeReflector
    {
        protected readonly BindingSettings bindingSettings = null;
        protected readonly IMethodAspectDefinition aspectDefinition = null;

        internal AbstractBindingMethodAspectWeaver(IMethodAspectDefinition aspectDefinition) {
            this.aspectDefinition = aspectDefinition;
            bindingSettings = aspectDefinition.ToBindingSettings();
        }

        public virtual FieldInfo WeavedType { get; private set; }
    }
}
