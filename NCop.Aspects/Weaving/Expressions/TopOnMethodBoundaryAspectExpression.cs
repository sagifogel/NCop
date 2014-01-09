using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopOnMethodBoundaryAspectExpression : AbstractAspectExpression
    {
        internal TopOnMethodBoundaryAspectExpression(IAspectExpression expression, IAspectDefinition aspectDefinition = null)
            : base(expression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var clonedSettings = aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });

            var nestedWeaver = aspectExpression.Reduce(clonedSettings);

            return new TopOnMethodBoundaryAspectWeaver(nestedWeaver, aspectDefinition, clonedSettings);
        }
    }
}
