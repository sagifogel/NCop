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
        internal MethodImplArgumentsWeaver(IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings, ILocalBuilderRepository localBuilderRepository)
            : base(argumentWeavingSettings, aspectWeavingSettings, localBuilderRepository) {
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters) {
            LocalBuilder bindingLocalBuilder = null;
            FieldBuilder contractFieldBuilder = null;
            var declaredLocalBuilder = ilGenerator.DeclareLocal(ArgumentType);
            var ctorInterceptionArgs = ArgumentType.GetConstructors().First();
            var ctorInterceptionArgsParams = ctorInterceptionArgs.GetParameters();
            var bindingType = ctorInterceptionArgsParams[1].ParameterType;

            ilGenerator.EmitLoadArg(0);
            bindingLocalBuilder = LocalBuilderRepository.Get(bindingType);
            contractFieldBuilder = WeavingSettings.TypeDefinition.GetFieldBuilder(WeavingSettings.ContractType);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);
            ilGenerator.EmitLoadLocal(bindingLocalBuilder);

            parameters.ForEach(1, (parameter, i) => {
                ilGenerator.EmitLoadArg(i);
            });

            ilGenerator.Emit(OpCodes.Newobj, ctorInterceptionArgs);
            ilGenerator.EmitStoreLocal(declaredLocalBuilder);

            return declaredLocalBuilder;
        }
    }
}
