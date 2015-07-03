using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingMethodInterceptionArgumentsWeaver : AbstractBindingMethodInterceptionArgumentsWeaver
    {
        private readonly Type topAspectInScopeArgType = null;

        internal BindingMethodInterceptionArgumentsWeaver(MethodInfo method, Type topAspectInScopeArgType, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, argumentWeavingSettings, aspectWeavingSettings) {
            this.topAspectInScopeArgType = topAspectInScopeArgType;
        }

        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            var localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            var previousAspectArgsLocalBuilder = localBuilderRepository.Get(topAspectInScopeArgType);

            ilGenerator.EmitLoadLocal(previousAspectArgsLocalBuilder);
        }
    }
}
