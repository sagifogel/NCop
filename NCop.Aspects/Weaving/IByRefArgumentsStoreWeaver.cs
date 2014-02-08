using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    interface IByRefArgumentsStoreWeaver
    {
        void StoreLocalsIfNeeded(ILGenerator ilGenerator);
        void RestoreLocals(ILGenerator ilGenerator);
    }
}
