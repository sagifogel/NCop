using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection.Emit;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving
{
    internal class BindingOnMethodExecutionArgumentsWeaver : AbstractArgumentsWeaver
    {
        internal BindingOnMethodExecutionArgumentsWeaver(IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            LocalBuilder delegateLocalBuilder = null;
            LocalBuilder argsImplLocalBuilder = null;
            var ctorInterceptionArgs = ArgumentType.GetConstructors().First();
            var delegateType = Parameters.GetDelegateType(IsFunction);
            var delegateCtor = delegateType.GetConstructors()[0];
            var aspectRepository = aspectWeavingSettings.AspectRepository;
            var delegateGetMethodMethodInfo = typeof(Delegate).GetProperty("Method").GetGetMethod();
            var methodProperty = ArgumentType.GetProperty("Method");

            delegateLocalBuilder = LocalBuilderRepository.GetOrDeclare(delegateType, () => {
                return ilGenerator.DeclareLocal(delegateType);
            });

            argsImplLocalBuilder = LocalBuilderRepository.GetOrDeclare(ArgumentType, () => {
                return ilGenerator.DeclareLocal(ArgumentType);
            });

            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Ldind_Ref);
            ilGenerator.EmitLoadArg(2);
            ilGenerator.Emit(OpCodes.Callvirt, methodProperty.GetGetMethod());

            Parameters.ForEach(1, (parameter, i) => {
                var property = ArgumentType.GetProperty("Arg{0}".Fmt(i));

                ilGenerator.EmitLoadArg(2);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
            });

            ilGenerator.Emit(OpCodes.Newobj, ctorInterceptionArgs);
            ilGenerator.EmitStoreLocal(argsImplLocalBuilder);
        }
    }
}

