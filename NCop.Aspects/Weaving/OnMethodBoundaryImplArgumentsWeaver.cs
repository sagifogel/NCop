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
    internal class OnMethodBoundaryImplArgumentsWeaver : AbstractAspectArgumentsWeaver
    {
        internal OnMethodBoundaryImplArgumentsWeaver(IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters) {
            FieldBuilder contractFieldBuilder = null;
            var declaredLocalBuilder = ilGenerator.DeclareLocal(ArgumentType);
            var ctorInterceptionArgs = ArgumentType.GetConstructors().First();
            
            ilGenerator.EmitLoadArg(0);
            contractFieldBuilder = WeavingSettings.TypeDefinition.GetFieldBuilder(WeavingSettings.ContractType);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);

            parameters.ForEach(1, (parameter, i) => {
                ilGenerator.EmitLoadArg(i);
            });

            ilGenerator.Emit(OpCodes.Newobj, ctorInterceptionArgs);
            ilGenerator.EmitStoreLocal(declaredLocalBuilder);

            return declaredLocalBuilder;
        }
    }
}
