using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public interface ITypeDefinition
    {
		Type Type { get; }
        TypeBuilder TypeBuilder { get; }
        FieldBuilder GetFieldBuilder(Type type);
    }
}
