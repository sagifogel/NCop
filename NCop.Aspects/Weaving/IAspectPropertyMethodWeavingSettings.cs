using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public interface IAspectPropertyMethodWeavingSettings : IAspectMethodWeavingSettings
    {
        PropertyInfo PropertyInfoContract { get; }
    }
}
