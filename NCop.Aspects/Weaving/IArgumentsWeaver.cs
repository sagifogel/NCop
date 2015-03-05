using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public interface IArgumentsWeaver
    {
        void Weave(ILGenerator ilGenerator);        
    }
}
