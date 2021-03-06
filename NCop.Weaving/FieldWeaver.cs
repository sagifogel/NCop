﻿using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class FieldWeaver : IFieldWeaver
    {
        private readonly string fieldName = null;
        private readonly TypeBuilder typeBuilder = null;
        private readonly FieldAttributes? fieldAttributes;

        public FieldWeaver(TypeBuilder typeBuilder, Type type, string fieldName = null, FieldAttributes? fieldAttributes = null) {
            FieldType = type;
            this.fieldName = fieldName;
            this.typeBuilder = typeBuilder;
            this.fieldAttributes = fieldAttributes ?? FieldAttributes.Private;
        }

        public Type FieldType { get; private set; }

        public FieldBuilder Weave() {
            return typeBuilder.DefineField(FieldType, fieldName, fieldAttributes);
        }
    }
}
