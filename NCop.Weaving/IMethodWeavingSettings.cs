using System.Reflection;

namespace NCop.Weaving
{
	public interface IMethodWeavingSettings : IWeavingSettings
	{
		MethodInfo MethodInfoImpl { get; }
	}
}
