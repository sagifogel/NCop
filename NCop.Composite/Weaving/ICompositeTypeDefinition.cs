using NCop.Weaving;
using System;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    public interface ICompositeTypeDefinition : ITypeDefinition
    {
        FieldBuilder GetEventFieldBuilder(string name, Type type);
    }
}
