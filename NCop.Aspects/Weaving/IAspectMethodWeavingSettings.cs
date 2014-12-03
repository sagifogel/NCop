using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
    public interface IAspectMethodWeavingSettings : IAspectWeavingSettings
    {
        IMethodWeavingSettings WeavingSettings { get; }
    }
}
