using System.Reflection;

namespace NCop.Aspects.Aspects
{
    public interface IPropertyAspectDefinition : IAspectDefinition
    {
        PropertyInfo Property { get; }
    }
}
