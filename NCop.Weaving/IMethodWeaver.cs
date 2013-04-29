using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public interface IMethodWeaver : IWeaver
    {
        IMethodEndWeaver MethodEndWeaver { get; }
        IMethodScopeWeaver MethodScopeWeaver { get; }
        void WeaveEndMethod(ILGenerator ilGenerator);
        IMethodSignatureWeaver MethodDefintionWeaver { get; }
        MethodBuilder DefineMethod(ITypeDefinition typeDefinition);
        ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition);
    }
}
