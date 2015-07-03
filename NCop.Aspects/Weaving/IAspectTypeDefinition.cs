using NCop.Weaving;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public interface IAspectTypeDefinition : ITypeDefinition
    {
        FieldBuilder GetEventFieldBuilder(string name, Type type);
        EventBrokerFieldTypeDefinition GetEventBrokerFielTypeDefinition(EventInfo @event);
    }
}
