using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractBindingPropertyAspectWeaver : IBindingTypeReflector
    {
        protected readonly BindingSettings bindingSettings = null;
        protected readonly IPropertyAspectDefinition aspectDefinition = null;

        internal AbstractBindingPropertyAspectWeaver(IPropertyAspectDefinition aspectDefinition) {
            this.aspectDefinition = aspectDefinition;
            bindingSettings = aspectDefinition.ToBindingSettings();
        }

        public virtual FieldInfo WeavedType { get; set; }
    }
}
