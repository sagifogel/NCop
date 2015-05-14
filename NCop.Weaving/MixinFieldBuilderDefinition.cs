using System;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class MixinFieldBuilderDefinition : AbstractFieldBuilderDefinition
    {
        public MixinFieldBuilderDefinition(Type mixinType, TypeBuilder typeBuilder)
            : base(mixinType, typeBuilder) {
        }
    }
}
