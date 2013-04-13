using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Core.Weaving
{
    public class MethodSignatureWeaver : IMethodSignatureWeaver
    {
        public MethodBuilder Weave(MethodInfo methodInfo, ITypeDefinition typeDefinition) {
            return typeDefinition.TypeBuilder.DefineMethod(methodInfo);
        }
    }
}
