using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractBindingAspectWeaver : IBindingTypeReflector
    {
        protected readonly BindingSettings bindingSettings = null;
        protected readonly IAspectDefinition aspectDefinition = null;

        internal AbstractBindingAspectWeaver(IAspectDefinition aspectDefinition) {
            this.aspectDefinition = aspectDefinition;
            bindingSettings = aspectDefinition.ToBindingSettings();
        }

        public virtual FieldInfo WeavedType { get; private set; }
    }
}
