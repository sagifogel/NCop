using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    public interface ICanEmitLocalBuilderByRefArgumentsWeaver : IByRefArgumentsStoreWeaver
    {
        void EmitLoadLocalAddress(ILGenerator ilGenerator, int argPosition);
    }
}
