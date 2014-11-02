using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class TopBindingOnMethodBoundaryAspectExpression : AbstractAspectMethodExpression
    {
        internal TopBindingOnMethodBoundaryAspectExpression(IAspectMethodExpression aspectExpression, IAspectDefinition aspectDefinition)
            : base(aspectExpression, aspectDefinition) {
        }

		public override IAspectWeaver Reduce(IAspectMethodWeavingSettings aspectWeavingSettings) {
            var topBindingArgType = aspectDefinition.ToAspectArgumentImpl();
             var methodInfoImpl = aspectWeavingSettings.WeavingSettings.MethodInfoImpl;

            var clonedSettings = aspectWeavingSettings.CloneWith(settings => {
                settings.ByRefArgumentsStoreWeaver = new BindingByRefArgumentsWeaverImpl(topBindingArgType, methodInfoImpl, settings.LocalBuilderRepository);
            });

            var nestedWeaver = aspectExpression.Reduce(clonedSettings);

            return new TopBindingOnMethodBoundaryAspectWeaver(nestedWeaver, aspectDefinition, clonedSettings);
        }
    }
}
