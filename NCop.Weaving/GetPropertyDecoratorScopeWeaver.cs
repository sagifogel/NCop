using NCop.Weaving.Extensions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class GetPropertyDecoratorScopeWeaver : AbstractMethodScopeWeaver
    {
        public GetPropertyDecoratorScopeWeaver(MethodInfo method, IWeavingSettings weavingSettings)
            : base(method, weavingSettings) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            var fieldBuilder = TypeDefinition.GetFieldBuilder(ContractType);

            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, Method);
        }
    }
}
