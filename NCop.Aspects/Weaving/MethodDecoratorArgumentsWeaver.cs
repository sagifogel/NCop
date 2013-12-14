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
    internal class MethodDecoratorArgumentsWeaver : AbstractArgumentsWeaver
    {
        internal MethodDecoratorArgumentsWeaver(Type argumentType, Type[] parameters, IWeavingSettings weavingSettings)
            : base(argumentType, parameters, weavingSettings, null) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            var @params = parameters.Skip(1);

            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Ldind_Ref);

            @params.ForEach(2, (parameter, i) => {
                ilGenerator.EmitLoadArg(i);
            });
        }
    }
}
