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
        MethodInfo MethodInfo { get; }
        MethodBuilder DefineMethod();
        ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition);
        void WeaveEndMethod(ILGenerator ilGenerator);
    }
}
