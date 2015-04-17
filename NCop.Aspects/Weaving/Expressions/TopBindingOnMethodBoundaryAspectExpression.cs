using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class TopBindingOnMethodBoundaryAspectExpression : AbstractAspectMethodExpression
    {
        internal TopBindingOnMethodBoundaryAspectExpression(IAspectExpression aspectExpression, IMethodAspectDefinition aspectDefinition)
            : base(aspectExpression, aspectDefinition) {
        }

		public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var topBindingArgType = aspectDefinition.ToAspectArgumentImpl();
            var clonedSettings = aspectWeavingSettings.CloneWith(settings => {
                settings.ByRefArgumentsStoreWeaver = new BindingByRefArgumentsWeaverImpl(topBindingArgType, aspectDefinition.Member, settings.LocalBuilderRepository);
            });

            var nestedWeaver = aspectExpression.Reduce(clonedSettings);

            return new TopBindingOnMethodBoundaryAspectWeaver(nestedWeaver, aspectDefinition, clonedSettings);
        }
    }
}
