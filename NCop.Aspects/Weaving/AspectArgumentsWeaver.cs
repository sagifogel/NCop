using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class AspectArgumentsWeaver : AbstractAspectArgumentsWeaver
    {
        internal AspectArgumentsWeaver(Type argsType, Type[] parameters)
            : base(argsType, parameters) {
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters) {
            var localBuilder = ilGenerator.DeclareLocal(ArgumentType);

            parameters[0] = parameters[0].MakeByRefType();
            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Ldind_Ref);

            parameters.Skip(1)
                      .ForEach(2, (parameter, i) => {
                          ilGenerator.EmitLoadArg(i);
                      });

            ilGenerator.Emit(OpCodes.Newobj, localBuilder.LocalType);
            ilGenerator.EmitStoreLocal(localBuilder);

            return localBuilder;
        }
    }
}
