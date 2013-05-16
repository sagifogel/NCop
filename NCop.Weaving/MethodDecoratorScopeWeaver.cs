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
    public class MethodDecoratorScopeWeaver : IMethodScopeWeaver
    {
        private readonly Type contractType = null;
        private readonly MethodInfo methodInfo = null;
        private readonly Type implementationType = null;

        public MethodDecoratorScopeWeaver(MethodInfo methodInfo, Type implementationType, Type contractType) {
            this.methodInfo = methodInfo;
            this.contractType = contractType;
            this.implementationType = implementationType;
        }

        public ILGenerator Weave(ILGenerator iLGenerator, ITypeDefinition typeDefinition) {
            FieldBuilder fieldBuilder = typeDefinition.GetOrAddFieldBuilder(contractType);

            iLGenerator.EmitLoadArg(0);
            iLGenerator.Emit(OpCodes.Ldfld, fieldBuilder);

            methodInfo.GetParameters()
                      .Select(p => p.ParameterType)
                      .ForEach(1, (paramType, i) => {
                          iLGenerator.EmitLoadArg(i);
                      });

            iLGenerator.Emit(OpCodes.Callvirt, methodInfo);

            return iLGenerator;
        }
    }
}
