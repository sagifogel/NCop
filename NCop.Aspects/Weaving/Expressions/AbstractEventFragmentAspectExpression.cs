using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal abstract class AbstractEventFragmentAspectExpression : AbstractAspectEventExpression
    {
        protected readonly IBindingTypeReflectorBuilder eventBuilder = null;

        internal AbstractEventFragmentAspectExpression(IAspectExpression aspectExpression, IBindingTypeReflectorBuilder eventBuilder, IEventAspectDefinition aspectDefinition = null)
            : base(aspectExpression, aspectDefinition) {
            this.eventBuilder = eventBuilder;
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var bindingWeaver = eventBuilder.Build(aspectWeavingSettings);
            
            var clonedSettings = aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });

            return CreateWeaver(clonedSettings, null/* bindingWeaver.WeavedType*/);
        }

        protected abstract IAspectWeaver CreateWeaver(IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType);
    }
}
