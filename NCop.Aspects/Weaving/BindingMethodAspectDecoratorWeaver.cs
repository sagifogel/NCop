using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Weaving;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingMethodAspectDecoratorWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        private readonly IBindingWeaver weaver = null;
        private readonly IMethodScopeWeaver methodDecoratorScopeWeaver = null;

        internal BindingMethodAspectDecoratorWeaver(IMethodAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings)
            : base(aspectDefinition.Method, aspectWeavingSettings.WeavingSettings) {
            var bindingSettings = aspectDefinition.ToBindingSettings();

            methodDecoratorScopeWeaver = new MethodDecoratorScopeWeaver(aspectDefinition.Method, aspectWeavingSettings);
            weaver = new MethodDecoratorBindingWeaver(aspectDefinition.Method, bindingSettings, aspectWeavingSettings, this);
        }

        public override void Weave(ILGenerator ilGenerator) {
            methodDecoratorScopeWeaver.Weave(ilGenerator);
        }
    }
}
