using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
    public interface IMethodWeaver : IWeaver
    {
        IMethodEndWeaver MethodEndWeaver { get; }
        IMethodScopeWeaver MethodScopeWeaver { get; }
        IMethodSignatureWeaver MethodDefintionWeaver { get; }
        MethodBuilder DefineMethod();
        void WeaveEndMethod(ILGenerator ilGenerator);
        ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition);
    }
}
