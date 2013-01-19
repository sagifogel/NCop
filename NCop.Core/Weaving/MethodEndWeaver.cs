using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
    public class MethodEndWeaver : IMethodEndWeaver
    {
        public void Weave(MethodInfo methodInfo, ILGenerator ilGenerator) {
            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}
