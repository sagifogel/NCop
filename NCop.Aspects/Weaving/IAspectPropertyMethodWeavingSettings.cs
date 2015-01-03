using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public interface IAspectPropertyMethodWeavingSettings : IAspectWeavingSettings
    {
        PropertyInfo PropertyInfoContract { get; }
    }
}
