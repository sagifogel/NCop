using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopOnMethodBoundaryAspectExpression : AbstractAspectExpression
    {
        internal TopOnMethodBoundaryAspectExpression(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition)
            : base(aspectExpression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var clonedAspectWeavingSettings = aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });

            var nestedWeaver = aspectExpression.Reduce(clonedAspectWeavingSettings);

            return new TopOnMethodBoundaryAspectWeaver(nestedWeaver, aspectDefinition, clonedAspectWeavingSettings);
        }
    }
}
