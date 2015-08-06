using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class MethodDecoratorScopeWeaver : AbstractMethodScopeWeaver
    {
        public MethodDecoratorScopeWeaver(MethodInfo method, IWeavingSettings weavingSettings)
            : base(method, weavingSettings) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            FieldBuilder fieldBuilder = TypeDefinition.GetFieldBuilder(ContractType);

            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, fieldBuilder);

            Method.GetParameters()
                      .Select(p => p.ParameterType)
                      .ForEach(1, (paramType, i) => ilGenerator.EmitLoadArg(i));

            ilGenerator.Emit(OpCodes.Callvirt, Method);
        }
    }
}
