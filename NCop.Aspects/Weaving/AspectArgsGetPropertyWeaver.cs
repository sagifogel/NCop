using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class AspectArgsGetPropertyWeaver : AbstractAspectPropertyArgsWeaver
    {
        internal AspectArgsGetPropertyWeaver(MethodInfo method, LocalBuilder methodLocalBuilder, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, methodLocalBuilder, aspectWeavingSettings) {
        }

        protected override Type PropertyType {
            get {
                return method.ReturnType;
            }
        }

        protected override string PropertyName {
            get {
                return method.Name.Replace("get_", "");
            }
        }

        protected override MethodInfo PropertyMethod {
            get {
                return typeof(PropertyInfo).GetMethod("GetGetMethod", Type.EmptyTypes);
            }
        }
    }
}
