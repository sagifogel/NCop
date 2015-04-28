
using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;
namespace NCop.Composite.Weaving
{
    internal class CompositeEventWeaver : IEventWeaver, IEventTypeBuilder
    {
        private IMethodWeaver onAddMethod = null;
        private IMethodWeaver onRemoveMethod = null;
        private readonly EventBuilder eventBuilder = null;

        public CompositeEventWeaver(ITypeDefinition typeDefinition, EventInfo @event) {
            eventBuilder = typeDefinition.TypeBuilder.DefineEvent(@event);
        }

        public void SetAddOnMethod(IMethodWeaver addOnMethod) {
            this.onAddMethod = addOnMethod;
        }

        public void SetRemoveOnMethod(IMethodWeaver onRemoveMethod) {
            this.onRemoveMethod = onRemoveMethod;
        }

        public IMethodWeaver GetOnAddMethod() {
            return onAddMethod;
        }

        public IMethodWeaver GetOnRemoveMethod() {
            return onRemoveMethod;
        }
    }
}
