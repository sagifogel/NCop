using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopOnMethodBoundaryArgumentsWeaver : AbstractTopAspectArgumentsWeaver<MethodInfo>
    {
        internal TopOnMethodBoundaryArgumentsWeaver(MethodInfo method, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator) {
            LocalBuilder methodLocalBuilder = null;
            FieldBuilder contractFieldBuilder = null;
            LocalBuilder aspectArgLocalBuilder = null;
            AspectArgsMethodWeaver methodWeaver = null;
            ConstructorInfo ctorInterceptionArgs = null;

            methodLocalBuilder = LocalBuilderRepository.Declare(() => {
                return ilGenerator.DeclareLocal(typeof(MethodInfo));
            });

            aspectArgLocalBuilder = ilGenerator.DeclareLocal(ArgumentType);
            contractFieldBuilder = WeavingSettings.TypeDefinition.GetFieldBuilder(WeavingSettings.ContractType);
            methodWeaver = new AspectArgsMethodWeaver(Member, methodLocalBuilder, Parameters, aspectWeavingSettings);
            methodWeaver.Weave(ilGenerator);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);
            ilGenerator.EmitLoadLocal(methodLocalBuilder);
            ctorInterceptionArgs = ArgumentType.GetConstructors()[0];

            Parameters.ForEach(1, (parameter, i) => {
                ilGenerator.EmitLoadArg(i);

                if (parameter.IsByRef) {
                    ilGenerator.Emit(OpCodes.Ldind_I4);
                }
            });

            ilGenerator.Emit(OpCodes.Newobj, ctorInterceptionArgs);
            ilGenerator.EmitStoreLocal(aspectArgLocalBuilder);

            return aspectArgLocalBuilder;
        }
    }
}
