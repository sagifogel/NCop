using System;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public interface ITypeDefinition
    {
        Type Type { get; }
        TypeBuilder TypeBuilder { get; }
        FieldBuilder GetFieldBuilder(Type type);
    }
}
