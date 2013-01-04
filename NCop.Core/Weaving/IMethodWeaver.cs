using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
    public interface IMethodWeaver : IWeaver
    {
        MethodBuilder DefineMethod(TypeBuilder typeBuilder);
        ILGenerator WeaveMethodScope(ILGenerator ilGenerator);
        void WeaveEndMethod(ILGenerator ilGenerator);
    }
}
