using System.Reflection.Emit;

namespace NCop.Weaving
{
    public interface IFieldWeaver : IWeaver
    {
        FieldBuilder Weave();
    }
}
