using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodDecoratorArgumentsWeaver : AbstractArgumentsWeaver
    {
        internal NestedMethodDecoratorArgumentsWeaver(IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            FieldBuilder contractFieldBuilder = null; 
            var argsLocalBuilder = LocalBuilderRepository.Get(ArgumentType);
            
            contractFieldBuilder = WeavingSettings.TypeDefinition.GetFieldBuilder(WeavingSettings.ContractType);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);

            Parameters.ForEach(1, (parameter, i) => {
                var property = ArgumentType.GetProperty("Arg{0}".Fmt(i));
                
                ilGenerator.EmitLoadLocal(argsLocalBuilder);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
            });
        }
    }
}
