using NCop.Weaving.Extensions;
using System.Reflection.Emit;
using NCop.Core.Extensions;
using System;
using System.Linq;

namespace NCop.Aspects.Weaving
{
    internal class NestedFunctionAspectArgsMappingWeaver : AbstractAspectArgsMappingWeaver
    {
        private readonly Type previousAspectArgType = null;
        private LocalBuilder previousAspectArgsLocalBuilder = null;

        internal NestedFunctionAspectArgsMappingWeaver(Type previousAspectArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsSettings argumentsSettings)
            : base(aspectWeavingSettings, argumentsSettings) {
            this.previousAspectArgType = previousAspectArgType;
        }

        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            WeaveLoadPreviousAspectLocal(ilGenerator);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            var argsLocalBuilder = localBuilderRepository.Get(aspectArgumentType);
            var contractFieldBuilder = weavingSettings.TypeDefinition.GetFieldBuilder(weavingSettings.ContractType);
            
            previousAspectArgsLocalBuilder = localBuilderRepository.Get(previousAspectArgType);
            ilGenerator.Emit(OpCodes.Pop);
            base.Weave(ilGenerator);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);

            parameters.ForEach(1, (parameter, i) => {
                var property = aspectArgumentType.GetProperty("Arg{0}".Fmt(i));

                WeaveLoadPreviousAspectLocal(ilGenerator);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
            });

            ilGenerator.Emit(OpCodes.Callvirt, weavingSettings.MethodInfoImpl);

            return ilGenerator;
        }

        private void WeaveLoadPreviousAspectLocal(ILGenerator ilGenerator) {
            ilGenerator.EmitLoadLocal(previousAspectArgsLocalBuilder);
        }
    }
}