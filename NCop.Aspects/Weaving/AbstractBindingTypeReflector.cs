using NCop.Aspects.Aspects;
using System.Reflection;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractBindingTypeReflector<TAspectDefintion> : IBindingTypeReflector where TAspectDefintion : class, IAspectDefinition
    {
        protected readonly BindingSettings bindingSettings = null;
        protected readonly TAspectDefintion aspectDefinition = null;

        public AbstractBindingTypeReflector(TAspectDefintion aspectDefinition) {
            this.aspectDefinition = aspectDefinition;
            bindingSettings = aspectDefinition.ToBindingSettings();
        }

        public abstract FieldInfo WeavedType { get; }
        protected abstract IAspectWeavingSettings GetAspectsWeavingSettings();
    }
}
