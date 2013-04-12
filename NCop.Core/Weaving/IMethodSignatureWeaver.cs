using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
    public interface IMethodSignatureWeaver : IWeaver
    {
        MethodBuilder Weave(MethodInfo methodInfo, ITypeDefinition typeDefinition);
    }
}