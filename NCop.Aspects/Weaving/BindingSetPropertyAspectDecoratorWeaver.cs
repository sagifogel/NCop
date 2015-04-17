using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingSetPropertyAspectDecoratorWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        private readonly IMethodScopeWeaver weaver = null;

        internal BindingSetPropertyAspectDecoratorWeaver(PropertyInfo property, IAspectWeavingSettings aspectWeavingSettings)
            : base(property.GetSetMethod(), aspectWeavingSettings.WeavingSettings) {
            weaver = new SetPropertyDecoratorScopeWeaver(property, aspectWeavingSettings);
        }

        public override void Weave(ILGenerator ilGenerator) {
            weaver.Weave(ilGenerator);
        }
    }
}
