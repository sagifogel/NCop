using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class BindingOnMethodBoundaryAspectExpression : AbstractAspectMethodExpression
    {
        private readonly IAspectDefinition topAspectInScopeDefinition = null;

        internal BindingOnMethodBoundaryAspectExpression(IAspectMethodExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectDefinition topAspectInScopeDefinition)
            : base(aspectExpression, aspectDefinition) {
            this.topAspectInScopeDefinition = topAspectInScopeDefinition;
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var topAspectInScopeArgType = topAspectInScopeDefinition.ToAspectArgumentImpl();

            var clonedSettings = aspectWeavingSettings.CloneWith(settings => {
                settings.ByRefArgumentsStoreWeaver = NullObjectByRefArgumentsStoreWeaver.Empty;
            });

            var nestedWeaver = aspectExpression.Reduce(clonedSettings);

            return new BindingOnMethodBoundaryAspectWeaver(topAspectInScopeArgType, nestedWeaver, aspectDefinition, clonedSettings);
        }
    }
}
