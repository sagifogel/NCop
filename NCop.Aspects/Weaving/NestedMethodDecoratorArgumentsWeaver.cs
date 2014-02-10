using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodDecoratorArgumentsWeaver : AbstractArgumentsWeaver
    {
        private readonly Type previousAspectArgType = null;
        private readonly IByRefArgumentsStoreWeaver byRefArgumentStoreWeaver = null;

        internal NestedMethodDecoratorArgumentsWeaver(Type previousAspectArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
            this.previousAspectArgType = previousAspectArgType;
            byRefArgumentStoreWeaver = aspectWeavingSettings.ByRefArgumentStoreWeaver;
        }

        public override void Weave(ILGenerator ilGenerator) {
            var argsLocalBuilder = LocalBuilderRepository.Get(previousAspectArgType);
            var contractFieldBuilder = WeavingSettings.TypeDefinition.GetFieldBuilder(WeavingSettings.ContractType);
            var methodImplParameters = WeavingSettings.MethodInfoImpl.GetParameters();

            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);

            methodImplParameters.ForEach(param => {
                int argPosition = param.Position + 1;

                if (byRefArgumentStoreWeaver.Contains(argPosition)) {
                    ilGenerator.EmitLoadArg(argPosition);
                }
                else {
                    var property = previousAspectArgType.GetProperty("Arg{0}".Fmt(param.Position + 1));

                    ilGenerator.EmitLoadLocal(argsLocalBuilder);
                    ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
                }
            });
        }
    }
}
