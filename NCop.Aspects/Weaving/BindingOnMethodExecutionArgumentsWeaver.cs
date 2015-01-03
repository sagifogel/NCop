using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingOnMethodExecutionArgumentsWeaver : AbstractBindingOnMethodExecutionArgumentsWeaver
    {
        private readonly Type topAspectInScopeArgType = null;

        internal BindingOnMethodExecutionArgumentsWeaver(MethodInfo methodInfo, Type topAspectInScopeArgType, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(methodInfo, argumentWeavingSettings, aspectWeavingSettings) {
            this.topAspectInScopeArgType = topAspectInScopeArgType;
        }

        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            var localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            var previousAspectArgsLocalBuilder = localBuilderRepository.Get(topAspectInScopeArgType);

            ilGenerator.EmitLoadLocal(previousAspectArgsLocalBuilder);
        }
    }
}

