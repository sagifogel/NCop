using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class FullPropertyInterceptionBindingWeaver : AbstractPropertyBindingWeaver
    {
        internal FullPropertyInterceptionBindingWeaver(PropertyInfo property, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IAspectWeaver getMethodScopeWeaver, IAspectWeaver setMethodScopeWeaver)
            : base(property, bindingSettings, aspectWeavingSettings, getMethodScopeWeaver, setMethodScopeWeaver) {
        }

        public override bool WeaveGetMethod {
            get {
                return true;
            }
        }

        public override bool WeaveSetMethod {
            get {
                return true;
            }
        }
    }
}
