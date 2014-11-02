using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
	public interface IAspectPropertyWeavingSettings : IAspectWeavingSettings
	{
		IPropertyWeavingSettings WeavingSettings { get; }
	}
}
