using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Weaving
{
    internal class FullPropertyBindingTypeReflectorBuilder : IPropertyExpressionBuilder
    {
        private IAspectExpression getAspectExpression = null;
        private IAspectExpression setAspectExpression = null;
        private Core.Lib.Lazy<IAspectExpression, IAspectExpression, IAspectWeavingSettings, IBindingTypeReflector> lazyBindingTypeReflector = null;

        public FullPropertyBindingTypeReflectorBuilder(IPropertyAspectDefinition aspectDefinition) {
            lazyBindingTypeReflector = new Core.Lib.Lazy<IAspectExpression, IAspectExpression, IAspectWeavingSettings, IBindingTypeReflector>((getAspectExpression, setAspectExpression, aspectWeavingSettings) => {
                return new IsolatedFullPropertyInterceptionBindingWeaver(getAspectExpression, setAspectExpression, aspectDefinition, aspectWeavingSettings);
            });
        }

        public void SetSetExpression(IAspectExpression getAspectExpression) {
            this.getAspectExpression = getAspectExpression;
        }

        public void SetGetExpression(IAspectExpression setAspectExpression) {
            this.setAspectExpression = setAspectExpression;
        }
        
        public IBindingTypeReflector Build(IAspectWeavingSettings aspectsWeavingSettings) {
            return lazyBindingTypeReflector.Get(getAspectExpression, setAspectExpression, aspectsWeavingSettings);
        }
    }
}
