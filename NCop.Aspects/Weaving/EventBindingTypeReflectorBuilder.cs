using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System;

namespace NCop.Aspects.Weaving
{
    internal class EventBindingTypeReflectorBuilder : IEventExpressionBuilder
    {
        private IAspectExpression addAspectExpression = null;
        private IAspectExpression removeAspectExpression = null;
        private IAspectExpression invokeAspectExpression = null;
        private readonly Core.Lib.Lazy<IAspectExpression, IAspectExpression, IAspectExpression, IAspectWeavingSettings, IBindingTypeReflector> lazyBindingTypeReflector = null;

        internal EventBindingTypeReflectorBuilder(IEventAspectDefinition aspectDefinition) {
            lazyBindingTypeReflector = new Core.Lib.Lazy<IAspectExpression, IAspectExpression, IAspectExpression, IAspectWeavingSettings, IBindingTypeReflector>((addAspectExpression, removeAspectExpression, invokeAspectExpression, aspectWeavingSettings) => {
                return null;
            });
        }

        public void SetAddExpression(IAspectExpression addAspectExpression) {
            this.addAspectExpression = addAspectExpression;
        }

        public void SetRemoveExpression(IAspectExpression removeAspectExpression) {
            this.removeAspectExpression = removeAspectExpression;
        }

        public void SetInvokeExpression(IAspectExpression invokeAspectExpression) {
            this.invokeAspectExpression = invokeAspectExpression;
        }

        public IBindingTypeReflector Build(IAspectWeavingSettings aspectsWeavingSettings) {
            return lazyBindingTypeReflector.Get(addAspectExpression, removeAspectExpression, invokeAspectExpression, aspectsWeavingSettings);
        }
    }
}
