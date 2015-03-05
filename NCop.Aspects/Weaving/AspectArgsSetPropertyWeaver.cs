using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class AspectArgsSetPropertyWeaver : AbstractAspectPropertyArgsWeaver
    {
        internal AspectArgsSetPropertyWeaver(MethodInfo methodInfo, LocalBuilder methodLocalBuilder, IAspectWeavingSettings aspectWeavingSettings)
            : base(methodInfo, methodLocalBuilder, aspectWeavingSettings) {
        }

        protected override string PropertyName {
            get {
                return methodInfo.Name.Replace("set_", "");
            }
        }

        protected override MethodInfo PropertyMethod {
            get {
                return typeof(PropertyInfo).GetMethod("GetSetMethod", Type.EmptyTypes);
            }
        }
    }
}
