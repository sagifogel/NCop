using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class GetPropertyInterceptionBindingWeaver : AbstractPropertyBindingWeaver
    {
        internal GetPropertyInterceptionBindingWeaver(PropertyInfo property, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IAspectWeaver methodScopeWeaver)
            : base(property, bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
        }

        public override bool WeaveGetMethod {
            get {
                return true;
            }
        }
    }
}
