using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopMethodInterceptionArgumentsWeaver : AbstractTopAspectArgumentsWeaver
    {
        internal TopMethodInterceptionArgumentsWeaver(IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters) {
            LocalBuilder argsImplLocalBuilder = null;
            LocalBuilder delegateLocalBuilder = null;
            FieldBuilder contractFieldBuilder = null;
            var ctorInterceptionArgs = ArgumentType.GetConstructors().First();
            var ctorInterceptionArgsParams = ctorInterceptionArgs.GetParameters();
            var delegateType = Parameters.GetDelegateType(IsFunction);
            var delegateCtor = delegateType.GetConstructors()[0];
            var delegateGetMethodMethodInfo = typeof(Delegate).GetProperty("Method").GetGetMethod();
            var bindingLocalBuilder = LocalBuilderRepository.Get(BindingsDependency.ReflectedType);

            delegateLocalBuilder = LocalBuilderRepository.GetOrDeclare(delegateType, () => {
                return ilGenerator.DeclareLocal(delegateType);
            });

            argsImplLocalBuilder = ilGenerator.DeclareLocal(ArgumentType);
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
            ilGenerator.Emit(OpCodes.Ldsfld, BindingsDependency);

            parameters.ForEach(1, (parameter, i) => {
                ilGenerator.EmitLoadArg(i);
            });

            ilGenerator.Emit(OpCodes.Newobj, ctorInterceptionArgs);
            ilGenerator.EmitStoreLocal(argsImplLocalBuilder);

            return argsImplLocalBuilder;
        }
    }
}
