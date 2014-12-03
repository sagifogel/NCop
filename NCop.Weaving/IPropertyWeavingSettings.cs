using System.Reflection;

namespace NCop.Weaving
{
	public interface IPropertyWeavingSettings : IWeavingSettings
	{
        PropertyInfo PropertyInfoImpl { get; }
        PropertyInfo PropertyInfoContract { get; }
	}
}
