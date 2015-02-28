using System.Reflection.Emit;

namespace NCop.Weaving
{
    public interface IMethodScopeWeaver : IWeaver
    {
        void Weave(ILGenerator ilGenerator);
    }
}
