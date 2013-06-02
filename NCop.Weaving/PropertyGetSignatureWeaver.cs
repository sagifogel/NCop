using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class PropertyGetSignatureWeaver : IMethodSignatureWeaver
    {
        public MethodBuilder Weave(MethodInfo methodInfo, ITypeDefinition typeDefinition) {
            return typeDefinition.TypeBuilder.DefineParameterlessMethod(methodInfo);
        }
    }
}
