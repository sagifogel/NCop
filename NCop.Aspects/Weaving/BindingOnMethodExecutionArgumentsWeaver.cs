using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection.Emit;
namespace NCop.Aspects.Weaving
{
    internal class BindingOnMethodExecutionArgumentsWeaver: AbstractAspectArgumentsWeaver
    {
        internal BindingOnMethodExecutionArgumentsWeaver(IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters) {
            var argsImplLocalBuilder = ilGenerator.DeclareLocal(ArgumentType);
            var ctorInterceptionArgs = ArgumentType.GetConstructors().First();
            
            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Ldind_Ref);

            parameters.ForEach(1, (parameter, i) => {
                var property = ArgumentType.GetProperty("Arg{0}".Fmt(i));

                ilGenerator.EmitLoadArg(2);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
            });

            ilGenerator.Emit(OpCodes.Newobj, ctorInterceptionArgs);
            ilGenerator.EmitStoreLocal(argsImplLocalBuilder);

            return argsImplLocalBuilder;
        }
    }
}

