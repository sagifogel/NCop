using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
    public class EndMethodWeaver : IWeaver
    {
        public void Weave(ILGenerator ilGenerator) {
            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}
