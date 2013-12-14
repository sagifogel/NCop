using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public interface IArgumentsWeaver
    {
        bool IsFunction { get; }
        Type ArgumentType { get; }
        void Weave(ILGenerator ilGenerator);
        ILocalBuilderRepository LocalBuilderRepository { get; }
    }
}
