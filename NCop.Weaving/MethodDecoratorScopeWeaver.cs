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
	public class MethodDecoratorScopeWeaver : AbstractMethodScopeWeaver
    {
		public MethodDecoratorScopeWeaver(IWeavingSettings weavingSettings)
			:base(weavingSettings) {
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            FieldBuilder fieldBuilder = TypeDefinition.GetFieldBuilder(ContractType);

            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, fieldBuilder);

            MethodInfoImpl.GetParameters()
                      .Select(p => p.ParameterType)
                      .ForEach(1, (paramType, i) => {
                          ilGenerator.EmitLoadArg(i);
                      });

            ilGenerator.Emit(OpCodes.Callvirt, MethodInfoImpl);

            return ilGenerator;
        }
    }
}
