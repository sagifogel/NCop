using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class MethodInvokerArgumentsWeaver : AbstractArgumentsWeaver<MethodInfo>
    {
        private readonly Type previousAspectArgType = null;
        private readonly IByRefArgumentsStoreWeaver byRefArgumentStoreWeaver = null;

        internal MethodInvokerArgumentsWeaver(MethodInfo method, Type previousAspectArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentWeavingSettings, IByRefArgumentsStoreWeaver byRefArgumentsStoreWeaver)
            : base(method, argumentWeavingSettings, aspectWeavingSettings) {
            this.previousAspectArgType = previousAspectArgType;
            this.byRefArgumentStoreWeaver = byRefArgumentsStoreWeaver;
        }

        public override void Weave(ILGenerator ilGenerator) {
            var argsLocalBuilder = LocalBuilderRepository.Get(previousAspectArgType);
            var methodImplParameters = Member.GetParameters();

            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Ldind_Ref);

            methodImplParameters.ForEach(param => {
                int argPosition = param.Position + 1;

                if (byRefArgumentStoreWeaver.Contains(argPosition)) {
                    byRefArgumentStoreWeaver.EmitLoadLocalAddress(ilGenerator, argPosition);
                }
                else {
                    var property = previousAspectArgType.GetProperty("Arg{0}".Fmt(argPosition));

                    ilGenerator.EmitLoadLocal(argsLocalBuilder);
                    ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
                }
            });
        }
    }
}

