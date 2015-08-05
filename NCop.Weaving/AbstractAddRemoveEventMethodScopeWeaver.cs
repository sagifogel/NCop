using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using NCop.Core.Extensions;
using NCop.Weaving.Extensions;

namespace NCop.Weaving
{
    public abstract class AbstractAddRemoveEventMethodScopeWeaver : AbstractMethodScopeWeaver
    {
        protected AbstractAddRemoveEventMethodScopeWeaver(MethodInfo method, IWeavingSettings weavingSettings)
            : base(method, weavingSettings) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            var contractFieldBuilder = weavingSettings.TypeDefinition.GetFieldBuilder(weavingSettings.ContractType);

            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);
            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Call, Method);
        }
    }
}
