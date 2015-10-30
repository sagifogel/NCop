using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class AspectArgsSetPropertyWeaver : AbstractAspectPropertyArgsWeaver
    {
        internal AspectArgsSetPropertyWeaver(PropertyInfo property, LocalBuilder propertyLocalBuilder, IAspectWeavingSettings aspectWeavingSettings)
            : base(property, propertyLocalBuilder, aspectWeavingSettings) {
        }
    }
}
