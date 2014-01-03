using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using NCop.Weaving.Extensions;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractAdviceWeaver : IMethodScopeWeaver
    {
        protected readonly Type aspectType = null;
        protected readonly IAspectRepository aspectRepository = null;
		protected readonly ILocalBuilderRepository localBuilderRepository = null;
        protected readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        public AbstractAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings) {
            aspectType = adviceWeavingSettings.AspectType;
            aspectRepository = adviceWeavingSettings.AspectRepository;
			localBuilderRepository = adviceWeavingSettings.LocalBuilderRepository;
            argumentsWeavingSettings = adviceWeavingSettings.ArgumentsWeavingSettings;
		}

        public virtual ILGenerator Weave(ILGenerator ilGenerator) {
            LocalBuilder argsLocalBuilder = null;
            var aspectMember = aspectRepository.GetAspectFieldByType(aspectType);
            var adviceMethod = aspectMember.FieldType.GetMethod(AdviceName);

            argsLocalBuilder = localBuilderRepository.Get(argumentsWeavingSettings.ArgumentType);
            ilGenerator.Emit(OpCodes.Ldsfld, aspectMember);
            ilGenerator.EmitLoadLocal(argsLocalBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, adviceMethod);

            return ilGenerator;
        }

        protected abstract string AdviceName { get; }
    }
}
