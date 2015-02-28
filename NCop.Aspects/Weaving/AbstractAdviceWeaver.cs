using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractAdviceWeaver : IMethodScopeWeaver
    {
        protected readonly Type aspectType = null;
        protected readonly IAspectRepository aspectRepository = null;
		protected readonly ILocalBuilderRepository localBuilderRepository = null;
        protected readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        protected AbstractAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings) {
            aspectType = adviceWeavingSettings.AspectType;
            aspectRepository = adviceWeavingSettings.AspectRepository;
			localBuilderRepository = adviceWeavingSettings.LocalBuilderRepository;
            argumentsWeavingSettings = adviceWeavingSettings.ArgumentsWeavingSettings;
		}

        public virtual void Weave(ILGenerator ilGenerator) {
            LocalBuilder argsLocalBuilder = null;
            var aspectMember = aspectRepository.GetAspectFieldByType(aspectType);
            var adviceMethod = aspectMember.FieldType.GetMethod(AdviceName);

            argsLocalBuilder = localBuilderRepository.Get(argumentsWeavingSettings.ArgumentType);
            ilGenerator.Emit(OpCodes.Ldsfld, aspectMember);
            ilGenerator.EmitLoadLocal(argsLocalBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, adviceMethod);
        }

        protected abstract string AdviceName { get; }
    }
}
