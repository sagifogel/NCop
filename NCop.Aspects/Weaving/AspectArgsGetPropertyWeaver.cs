using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class AspectArgsGetPropertyWeaver : AbstractAspectPropertyArgsWeaver
    {
        internal AspectArgsGetPropertyWeaver(PropertyInfo property, LocalBuilder methodLocalBuilder, IAspectWeavingSettings aspectWeavingSettings)
            : base(property, methodLocalBuilder, aspectWeavingSettings) {
        }
    }
}
