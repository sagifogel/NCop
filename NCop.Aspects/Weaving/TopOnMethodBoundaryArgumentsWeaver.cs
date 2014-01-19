using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopOnMethodBoundaryArgumentsWeaver : AbstractTopAspectArgumentsWeaver
    {
        internal TopOnMethodBoundaryArgumentsWeaver(IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters) {
            FieldBuilder contractFieldBuilder = null;
            var aspectArgLocalBuilder = ilGenerator.DeclareLocal(ArgumentType);
            var ctorInterceptionArgs = aspectArgLocalBuilder.LocalType.GetConstructors().First();

            ilGenerator.EmitLoadArg(0);
            contractFieldBuilder = WeavingSettings.TypeDefinition.GetFieldBuilder(WeavingSettings.ContractType);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);

            parameters.ForEach(1, (parameter, i) => {
                ilGenerator.EmitLoadArg(i);
            });

            ilGenerator.Emit(OpCodes.Newobj, ctorInterceptionArgs);
            ilGenerator.EmitStoreLocal(aspectArgLocalBuilder);

            return aspectArgLocalBuilder;
        }
    }
}
