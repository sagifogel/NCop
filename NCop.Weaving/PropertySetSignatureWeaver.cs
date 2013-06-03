using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class PropertySetSignatureWeaver : IMethodSignatureWeaver
    {
        public MethodBuilder Weave(MethodInfo methodInfo, ITypeDefinition typeDefinition) {
            return typeDefinition.TypeBuilder.DefineMethod(methodInfo);
        }
    }
}