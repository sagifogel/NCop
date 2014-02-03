using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodDecoratorArgumentsWeaver : AbstractArgumentsWeaver
    {
        private readonly Type previousAspectArgType = null;

        internal NestedMethodDecoratorArgumentsWeaver(Type previousAspectArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
            this.previousAspectArgType = previousAspectArgType;
        }

        public override void Weave(ILGenerator ilGenerator) {
            var aspectArgsType = Parameters.ToAspectArgument(IsFunction);
            var argsLocalBuilder = LocalBuilderRepository.Get(previousAspectArgType);
            var contractFieldBuilder = WeavingSettings.TypeDefinition.GetFieldBuilder(WeavingSettings.ContractType);

            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);

            Parameters.ForEach(1, (parameter, i) => {
                var property = aspectArgsType.GetProperty("Arg{0}".Fmt(i));

                ilGenerator.EmitLoadLocal(argsLocalBuilder);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
            });
        }
    }
}
