using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Composite.Weaving;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using NCop.Aspects.Framework;
using NCop.Aspects.Engine;
using NCop.Core.Extensions;
using System.Threading;
using NCop.Weaving.Extensions;
namespace NCop.Aspects.Weaving
{
    internal class MethodImplArgumentsWeaver : AbstractAspectArgumentsWeaver
    {
        internal MethodImplArgumentsWeaver(Type argsType, Type[] parameters)
            : base(argsType, parameters) {
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters) {
            var localBuilder = ilGenerator.DeclareLocal(ArgumentType);

            ilGenerator.EmitLoadArg(0);
            ilGenerator.EmitLoadLocal(localBuilder);

            parameters.ForEach(1, (parameter, i) => {
                ilGenerator.EmitLoadArg(i);
            });

            ilGenerator.Emit(OpCodes.Newobj, localBuilder.LocalType);
            ilGenerator.EmitStoreLocal(localBuilder);

            return localBuilder;
        }
    }
}
