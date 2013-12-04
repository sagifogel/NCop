using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using NCop.Weaving.Extensions;
using NCop.Core.Extensions;

namespace NCop.Weaving
{
    public class PropertySetDecoratorScopeWeaver : AbstractMethodScopeWeaver
    {
		public PropertySetDecoratorScopeWeaver(IWeavingSettings weavingSettings)
            : base(weavingSettings) {
        }

        public override ILGenerator Weave(ILGenerator iLGenerator) {
            FieldBuilder fieldBuilder = TypeDefinition.GetFieldBuilder(ContractType);

            iLGenerator.EmitLoadArg(0);

            iLGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
            iLGenerator.EmitLoadArg(1);
            iLGenerator.Emit(OpCodes.Callvirt, MethodInfoImpl);

            return iLGenerator;
        }
    }
}
