using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System;

namespace NCop.Aspects.Weaving
{
    internal class SetPropertyBindingTypeReflectorBuilder : IPropertyExpressionBuilder
    {
        private IAspectExpression setAspectExpression = null;
        private readonly Core.Lib.Lazy<IAspectExpression, IAspectWeavingSettings, IBindingTypeReflector> lazyBindingTypeReflector = null;

        public SetPropertyBindingTypeReflectorBuilder(IPropertyAspectDefinition aspectDefinition) {
            lazyBindingTypeReflector = new Core.Lib.Lazy<IAspectExpression, IAspectWeavingSettings, IBindingTypeReflector>((setAspectExpression, aspectWeavingSettings) => {
                return new IsolatedSetPropertyInterceptionBindingWeaver(setAspectExpression, aspectDefinition, aspectWeavingSettings);
            });
        }

        public void SetSetExpression(IAspectExpression setAspectExpression) {
            this.setAspectExpression = setAspectExpression;
        }

        public void SetGetExpression(IAspectExpression getAspectExpression) {
        }

        public IBindingTypeReflector Build(IAspectWeavingSettings aspectsWeavingSettings) {
            return lazyBindingTypeReflector.Get(setAspectExpression, aspectsWeavingSettings);
        }
    }
}
