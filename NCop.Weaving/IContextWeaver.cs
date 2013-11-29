using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public interface IContextWeaver : IWeaver
    {
        void Weave(ILGenerator iLGenerator);
    }
}
