using NCop.Weaving.Extensions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class SetPropertyDecoratorScopeWeaver : AbstractMethodScopeWeaver
    {
        public SetPropertyDecoratorScopeWeaver(MethodInfo method, IWeavingSettings weavingSettings)
            : base(method, weavingSettings) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            FieldBuilder fieldBuilder = TypeDefinition.GetFieldBuilder(ContractType);

            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Callvirt, Method);
        }
    }
}
