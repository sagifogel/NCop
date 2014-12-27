using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingPropertyAspectDecoratorWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        private readonly IMethodScopeWeaver weaver = null;

        internal BindingPropertyAspectDecoratorWeaver(IAspectPropertyMethodWeavingSettings aspectWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            weaver = new GetPropertyDecoratorScopeWeaver(aspectWeavingSettings);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            return weaver.Weave(ilGenerator);
        }
    }
}
