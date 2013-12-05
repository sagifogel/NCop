using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class FieldWeaver : IFieldWeaver
    {
		private readonly TypeBuilder typeBuilder = null;

		public FieldWeaver(TypeBuilder typeBuilder, Type type) {
            FieldType = type;
			this.typeBuilder = typeBuilder;
        }

        public Type FieldType { get; private set; }

        public FieldBuilder Weave() {
            return typeBuilder.DefineField(FieldType);
        }
    }
}
