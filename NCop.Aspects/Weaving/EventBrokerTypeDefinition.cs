using NCop.Weaving;
using System;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public class EventBrokerTypeDefinition : AbstractTypeDefinition
    {
        public EventBrokerTypeDefinition(Type mixinType, TypeBuilder typeBuilder)
            : base(mixinType, typeBuilder) {
        }
    }
}
