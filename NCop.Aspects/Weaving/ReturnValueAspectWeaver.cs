using NCop.Aspects.Aspects;
using NCop.Composite.Weaving;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NCop.Weaving.Extensions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class ReturnValueAspectWeaver : IMethodScopeWeaver
    {
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;
        private readonly ILocalBuilderRepository localBuilderRepository = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSetings = null;

        internal ReturnValueAspectWeaver(IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSetings) {
            this.aspectWeavingSettings = aspectWeavingSettings;
            this.argumentsWeavingSetings = argumentsWeavingSetings;
            localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
        }

        public ILGenerator Weave(ILGenerator ilGenerator) {
            MethodInfo returnValueGetMethod = null;
            LocalBuilder argsImplLocalBuilder = null;
            var argumentType = argumentsWeavingSetings.ArgumentType;

            argsImplLocalBuilder = localBuilderRepository.Get(argumentType);
            ilGenerator.Emit(OpCodes.Pop);
            ilGenerator.EmitLoadLocal(argsImplLocalBuilder);
            returnValueGetMethod = argumentType.GetProperty("ReturnValue").GetGetMethod();
            ilGenerator.Emit(OpCodes.Callvirt, returnValueGetMethod);

            return ilGenerator;
        }
    }
}
