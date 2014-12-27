using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingMethodAspectDecoratorWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        private readonly IMethodBindingWeaver weaver = null;
        private readonly IMethodScopeWeaver methodDecoratorScopeWeaver = null;

        internal BindingMethodAspectDecoratorWeaver(IAspectDefinition aspectDefinition, IAspectMethodWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            var bindingSettings = aspectDefinition.ToBindingSettings();

            bindingSettings.LocalBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            methodDecoratorScopeWeaver = new MethodDecoratorScopeWeaver(aspectWeavingSettings);
            weaver = new MethodDecoratorBindingWeaver(bindingSettings, aspectWeavingSettings, this);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            return methodDecoratorScopeWeaver.Weave(ilGenerator);
        }
    }
}
