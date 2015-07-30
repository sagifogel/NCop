using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class FieldBuilderDefinition : IFieldBuilderDefinition
    {
        public FieldBuilderDefinition(Type type, TypeBuilder typeBuilder, string fieldName = null, FieldAttributes? fieldAttributes = null) {
            Type = type;
            FieldBuilder = new FieldWeaver(typeBuilder, type, fieldName, fieldAttributes).Weave();
        }

        public Type Type { get; private set; }

        public FieldBuilder FieldBuilder { get; private set; }
    }
}
