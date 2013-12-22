using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public interface IArgumentsWeaver : IArgumentsWeavingSettings
    {
        void Weave(ILGenerator ilGenerator);        
    }
}
