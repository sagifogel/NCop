using System;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class MixinFieldBuilderDefinition : FieldBuilderDefinition
    {
        public MixinFieldBuilderDefinition(Type mixinType, TypeBuilder typeBuilder)
            : base(mixinType, typeBuilder) {
        }
    }
}
