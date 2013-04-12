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
        //private MethodAttributes _attributes;

        //public MethodSignatureWeaver(MethodAttributes attributes) {
        //    _attributes = attributes;
        //}

        public MethodBuilder Weave(MethodInfo methodInfo, ITypeDefinition typeDefinition) {
            return typeDefinition.TypeBuilder.DefineMethod(methodInfo);
        }
    }
}
