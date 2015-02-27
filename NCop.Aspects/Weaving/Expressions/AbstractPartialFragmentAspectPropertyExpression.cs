using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal abstract class AbstractPartialFragmentAspectPropertyExpression : AbstractPartialAspectPropertyExpression
    {
        protected readonly IBindingTypeReflectorBuilder propertyBuilder = null;

        internal AbstractPartialFragmentAspectPropertyExpression(IAspectExpression aspectExpression, IBindingTypeReflectorBuilder propertyBuilder, IPropertyAspectDefinition aspectDefinition = null)
            : base(aspectExpression, aspectDefinition) {
            this.propertyBuilder = propertyBuilder;
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var bindingWeaver = propertyBuilder.Build(aspectWeavingSettings);
            var clonedSettings = aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });

            return CreateWeaver(aspectDefinition, clonedSettings, bindingWeaver.WeavedType);
        }

        protected abstract IAspectWeaver CreateWeaver(IPropertyAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType);
    }
}
