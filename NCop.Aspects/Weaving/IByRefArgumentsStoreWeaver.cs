using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public interface IByRefArgumentsStoreWeaver
    {
        bool Contains(int argPosition);
        bool ContainsByRefParams { get; }
        void StoreArgsIfNeeded(ILGenerator ilGenerator);
        void RestoreArgsIfNeeded(ILGenerator ilGenerator);
        void EmitLoadLocalAddress(ILGenerator ilGenerator, int argPosition);
    }
}
