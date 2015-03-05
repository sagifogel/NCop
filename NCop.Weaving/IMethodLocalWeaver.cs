using System;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public interface IMethodLocalWeaver : IWeaver
    {
        Type ArgsType { get; }
        LocalBuilder Weave(ILGenerator ilGenerator);
    }
}
