using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class AspectArgsSetPropertyWeaver : AbstractAspectArgsPropertyWeaver
    {
        internal AspectArgsSetPropertyWeaver(LocalBuilder methodLocalBuilder, IAspectPropertyMethodWeavingSettings aspectWeavingSettings)
            : base(methodLocalBuilder, aspectWeavingSettings) {
        }

        protected override MethodInfo PropertyMethod {
            get {
                return typeof(PropertyInfo).GetMethod("GetSetMethod", Type.EmptyTypes);
            }
        }
    }
}
