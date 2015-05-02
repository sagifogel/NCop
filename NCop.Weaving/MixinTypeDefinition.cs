using System;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class MixinTypeDefinition : AbstractTypeDefinition
    {
        public MixinTypeDefinition(Type mixinType, TypeBuilder typeBuilder)
            : base(mixinType, typeBuilder) {
        }
    }
}
