using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
    public class InstanceFieldWeaver : IFieldWeaver
    {
        public InstanceFieldWeaver(Type type) {
            Type = type;
        }

        public Type Type { get; private set; }

        public FieldBuilder Weave(TypeBuilder typeBuilder) {
            throw new NotImplementedException();
        }
    }
}
