using System;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public interface IFieldBuilderDefinition
    {
        Type Type { get; }
        FieldBuilder FieldBuilder { get; }
    }
}
