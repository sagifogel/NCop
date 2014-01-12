using System.Reflection.Emit;
using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Linq;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodIntercpetionArgumentsWeaver : AbstractAspectArgumentsWeaver
    {
        private readonly Type previousAspectArgType = null;

        internal NestedMethodIntercpetionArgumentsWeaver(Type previousAspectArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
            this.previousAspectArgType = previousAspectArgType;
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator, System.Type[] parameters) {
            FieldBuilder contractFieldBuilder = null;
            var declaredLocalBuilder = ilGenerator.DeclareLocal(ArgumentType);
            var ctorInterceptionArgs = ArgumentType.GetConstructors().First();
            var argsLocalBuilder = LocalBuilderRepository.Get(previousAspectArgType);

            contractFieldBuilder = WeavingSettings.TypeDefinition.GetFieldBuilder(WeavingSettings.ContractType);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);
            ilGenerator.Emit(OpCodes.Ldsfld, BindingsDependency);

            Parameters.ForEach(1, (parameter, i) => {
                var property = ArgumentType.GetProperty("Arg{0}".Fmt(i));

                ilGenerator.EmitLoadLocal(argsLocalBuilder);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
            });

            ilGenerator.Emit(OpCodes.Newobj, ctorInterceptionArgs);
            ilGenerator.EmitStoreLocal(declaredLocalBuilder);

            return declaredLocalBuilder;
        }
    }
}