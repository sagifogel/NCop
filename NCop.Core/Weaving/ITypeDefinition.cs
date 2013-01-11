using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
    public interface ITypeDefinition
    {
        TypeBuilder TypeBuilder { get; }
        FieldBuilder GetOrAddFieldBuilder(Type type);
    }
}
