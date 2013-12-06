using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public interface IAspectArgumentWeaver
    {
        bool IsFunction { get; }
        Type ArgumentType { get; }
        LocalBuilder Weave(ILGenerator ilGenerator);
    }
}
