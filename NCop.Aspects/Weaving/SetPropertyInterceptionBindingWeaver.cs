using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class SetPropertyInterceptionBindingWeaver : AbstractPropertyBindingWeaver
    {
        internal SetPropertyInterceptionBindingWeaver(PropertyInfo propertyInfo, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IAspectWeaver methodScopeWeaver)
            : base(propertyInfo, bindingSettings, aspectWeavingSettings, setMethodScopeWeaver: methodScopeWeaver) {
        }

        public override bool WeaveSetMethod {
            get {
                return true;
            }
        }
    }
}
