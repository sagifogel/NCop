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
		MethodBuilder DefineMethod();
		IMethodEndWeaver MethodEndWeaver { get; }
		void WeaveEndMethod(ILGenerator ilGenerator);
		IMethodScopeWeaver MethodScopeWeaver { get; }
        IMethodSignatureWeaver MethodDefintionWeaver { get; }
        void WeaveMethodScope(ILGenerator ilGenerator);
    }
}
