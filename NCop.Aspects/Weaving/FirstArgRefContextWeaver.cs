using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using NCop.Weaving.Extensions;

namespace NCop.Aspects.Weaving
{
    public class FirstArgRefContextWeaver : IContextWeaver
    {   
        public void Weave(ILGenerator iLGenerator) {
            iLGenerator.EmitLoadArg(0);
            iLGenerator.Emit(OpCodes.Ldind_Ref);
        }
    }
}
