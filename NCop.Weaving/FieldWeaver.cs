using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class FieldWeaver : IFieldWeaver
    {
        public FieldWeaver(Type type) {
            FieldType = type;
        }

        public Type FieldType { get; private set; }

        public FieldBuilder Weave(TypeBuilder typeBuilder) {
            return typeBuilder.DefineField(FieldType);
        }
    }
}
