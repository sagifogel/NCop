using System.Reflection;
using System.Reflection.Emit;
using NCop.Weaving.Extensions;

namespace NCop.Aspects.Weaving
{
    internal class TopGetPropertyInterceptionArgumentsWeaver : AbstractTopAspectArgumentsWeaver
    {
        internal TopGetPropertyInterceptionArgumentsWeaver(IArgumentsWeavingSettings argumentWeavingSettings, IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator) {
            LocalBuilder methodLocalBuilder = null;
            FieldBuilder contractFieldBuilder = null;
            LocalBuilder aspectArgLocalBuilder = null;
            ConstructorInfo ctorInterceptionArgs = null;
            AspectArgsPropertyWeaver methodWeaver = null;

            methodLocalBuilder = LocalBuilderRepository.Declare(() => {
                return ilGenerator.DeclareLocal(typeof(MethodInfo));
            });

            ctorInterceptionArgs = ArgumentType.GetConstructors()[0];
            aspectArgLocalBuilder = ilGenerator.DeclareLocal(ArgumentType);
            contractFieldBuilder = WeavingSettings.TypeDefinition.GetFieldBuilder(WeavingSettings.ContractType);
            methodWeaver = new AspectArgsPropertyWeaver(methodLocalBuilder, typeof(string), aspectWeavingSettings);
            methodWeaver.Weave(ilGenerator);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);
            ilGenerator.EmitLoadLocal(methodLocalBuilder);
            ilGenerator.Emit(OpCodes.Ldsfld, BindingsDependency);

            
            ilGenerator.Emit(OpCodes.Newobj, ctorInterceptionArgs);
            ilGenerator.EmitStoreLocal(aspectArgLocalBuilder);

            return aspectArgLocalBuilder;
        }
    }
}