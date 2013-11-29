using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using NCop.Weaving.Extensions;

namespace NCop.Weaving
{
    public class ThisContextWeaver : IContextWeaver
    {
        private readonly Type type = null;

        public ThisContextWeaver(Type type) {
            this.type = type;
        }

        public void Weave(ILGenerator iLGenerator) {
            iLGenerator.EmitLoadArg(0);
        }
    }
}
