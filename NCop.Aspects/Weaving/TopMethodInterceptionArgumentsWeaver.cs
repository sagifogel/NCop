using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopMethodInterceptionArgumentsWeaver : AbstractTopAspectArgumentsWeaver
    {
        internal TopMethodInterceptionArgumentsWeaver(IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters) {
            LocalBuilder methodLocalBuilder = null;
            FieldBuilder contractFieldBuilder = null;
            LocalBuilder aspectArgLocalBuilder = null;
            AspectArgsMethodWeaver methodWeaver = null;
            ConstructorInfo ctorInterceptionArgs = null;

            methodLocalBuilder = LocalBuilderRepository.Declare(() => {
                return ilGenerator.DeclareLocal(typeof(MethodInfo));
            });

            ctorInterceptionArgs = ArgumentType.GetConstructors()[0];
            aspectArgLocalBuilder = ilGenerator.DeclareLocal(ArgumentType);
            contractFieldBuilder = WeavingSettings.TypeDefinition.GetFieldBuilder(WeavingSettings.ContractType);
            methodWeaver = new AspectArgsMethodWeaver(methodLocalBuilder, parameters, aspectWeavingSettings);
            methodWeaver.Weave(ilGenerator);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);
            ilGenerator.EmitLoadLocal(methodLocalBuilder);
            ilGenerator.Emit(OpCodes.Ldsfld, BindingsDependency);

            parameters.ForEach(1, (parameter, i) => {
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
