using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public interface IMethodLocalWeaver : IWeaver
    {
        LocalBuilder Weave(ILGenerator ilGenerator);
    }
}
