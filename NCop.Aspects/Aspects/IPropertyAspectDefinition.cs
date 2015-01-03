using System.Reflection;

namespace NCop.Aspects.Aspects
{
    public interface IPropertyAspectDefinition : IAspectDefinition
    {
        PropertyInfo PropertyInfo { get; }
    }
}
