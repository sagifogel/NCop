using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System;

namespace NCop.Aspects.Weaving
{
    internal class GetPropertyBindingTypeReflectorBuilder : IPropertyExpressionBuilder
    {
        private IAspectExpression getAspectExpression = null;
        private readonly Core.Lib.Lazy<IAspectExpression, IAspectWeavingSettings, IBindingTypeReflector> lazyBindingTypeReflector = null;

        public GetPropertyBindingTypeReflectorBuilder(IPropertyAspectDefinition aspectDefinition) {
            lazyBindingTypeReflector = new Core.Lib.Lazy<IAspectExpression, IAspectWeavingSettings, IBindingTypeReflector>((getAspectExpression, aspectWeavingSettings) => {
                return new IsolatedGetPropertyInterceptionBindingWeaver(getAspectExpression, aspectDefinition, aspectWeavingSettings);
            });
        }

        public void SetSetExpression(IAspectExpression setAspectExpression) {
        }

        public void SetGetExpression(IAspectExpression getAspectExpression) {
            this.getAspectExpression = getAspectExpression;
        }

        public IBindingTypeReflector Build(IAspectWeavingSettings aspectsWeavingSettings) {
            return lazyBindingTypeReflector.Get(getAspectExpression, aspectsWeavingSettings);
        }
    }
}
