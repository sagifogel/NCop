using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodInvokerArgumentsWeaver : AbstractArgumentsWeaver<MethodInfo>
    {
        private readonly Type topAspectInScopeArgType = null;
        private readonly IByRefArgumentsStoreWeaver byRefArgumentStoreWeaver = null;

        internal NestedMethodInvokerArgumentsWeaver(MethodInfo method, Type topAspectInScopeArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentWeavingSettings)
            : base(method, argumentWeavingSettings, aspectWeavingSettings) {
            this.topAspectInScopeArgType = topAspectInScopeArgType;
            byRefArgumentStoreWeaver = aspectWeavingSettings.ByRefArgumentsStoreWeaver;
        }

        public override void Weave(ILGenerator ilGenerator) {
            var argsLocalBuilder = LocalBuilderRepository.Get(topAspectInScopeArgType);
            var contractFieldBuilder = WeavingSettings.TypeDefinition.GetFieldBuilder(WeavingSettings.ContractType);
            var methodImplParameters = Member.GetParameters();

            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);

            methodImplParameters.ForEach(param => {
                int argPosition = param.Position + 1;

                if (byRefArgumentStoreWeaver.Contains(argPosition)) {
                    ilGenerator.EmitLoadArg(argPosition);
                }
                else {
                    var property = topAspectInScopeArgType.GetProperty("Arg{0}".Fmt(argPosition));

                    ilGenerator.EmitLoadLocal(argsLocalBuilder);
                    ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
                }
            });
        }
    }
}
