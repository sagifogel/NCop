using NCop.Weaving.Extensions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class GetPropertyDecoratorScopeWeaver : AbstractMethodScopeWeaver
    {
        public GetPropertyDecoratorScopeWeaver(MethodInfo methodInfo, IWeavingSettings weavingSettings)
            : base(methodInfo, weavingSettings) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            var fieldBuilder = TypeDefinition.GetFieldBuilder(ContractType);

            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfo);
        }
    }
}
