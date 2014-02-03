using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopOnMethodBoundaryArgumentsWeaver : AbstractTopAspectArgumentsWeaver
    {
        internal TopOnMethodBoundaryArgumentsWeaver(IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters) {
            LocalBuilder aspectArgLocalBuilder = null;
            ConstructorInfo ctorInterceptionArgs = null;
            LocalBuilder delegateLocalBuilder = null;
            FieldBuilder contractFieldBuilder = null;
            var delegateType = Parameters.GetDelegateType(IsFunction);
            var delegateCtor = delegateType.GetConstructors()[0];
            var delegateGetMethodMethodInfo = typeof(Delegate).GetProperty("Method").GetGetMethod();

            delegateLocalBuilder = LocalBuilderRepository.GetOrDeclare(delegateType, () => {
                return ilGenerator.DeclareLocal(delegateType);
            });

            ilGenerator.EmitLoadArg(0);
            contractFieldBuilder = WeavingSettings.TypeDefinition.GetFieldBuilder(WeavingSettings.ContractType);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);
            ilGenerator.Emit(OpCodes.Dup);
            ilGenerator.Emit(OpCodes.Ldvirtftn, WeavingSettings.MethodInfoImpl);
            ilGenerator.Emit(OpCodes.Newobj, delegateCtor);
            ilGenerator.EmitStoreLocal(delegateLocalBuilder);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);
            ilGenerator.EmitLoadLocal(delegateLocalBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, delegateGetMethodMethodInfo);
            aspectArgLocalBuilder = ilGenerator.DeclareLocal(ArgumentType);
            ctorInterceptionArgs = ArgumentType.GetConstructors().First();

            parameters.ForEach(1, (parameter, i) => {
                ilGenerator.EmitLoadArg(i);
            });

            ilGenerator.Emit(OpCodes.Newobj, ctorInterceptionArgs);
            ilGenerator.EmitStoreLocal(aspectArgLocalBuilder);

            return aspectArgLocalBuilder;
        }
    }
}
