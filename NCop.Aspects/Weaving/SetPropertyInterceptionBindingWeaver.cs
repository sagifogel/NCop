using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class SetPropertyInterceptionBindingWeaver : AbstractPropertyBindingWeaver
    {
        internal SetPropertyInterceptionBindingWeaver(PropertyInfo property, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IAspectWeaver methodScopeWeaver)
            : base(property, bindingSettings, aspectWeavingSettings, setMethodScopeWeaver: methodScopeWeaver) {
        }

        public override bool WeaveSetMethod {
            get {
                return true;
            }
        }
    }
}
