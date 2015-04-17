using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingGetPropertyAspectDecoratorWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        private readonly IMethodScopeWeaver weaver = null;

        internal BindingGetPropertyAspectDecoratorWeaver(PropertyInfo property, IAspectWeavingSettings aspectWeavingSettings)
            : base(property.GetGetMethod(), aspectWeavingSettings.WeavingSettings) {
            weaver = new GetPropertyDecoratorScopeWeaver(property, aspectWeavingSettings);
        }

        public override void Weave(ILGenerator ilGenerator) {
            weaver.Weave(ilGenerator);
        }
    }
}
