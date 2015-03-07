using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class AspectArgsSetPropertyWeaver : AbstractAspectPropertyArgsWeaver
    {
        private readonly Type propertyType = null;

        internal AspectArgsSetPropertyWeaver(MethodInfo methodInfo, LocalBuilder methodLocalBuilder, IAspectWeavingSettings aspectWeavingSettings)
            : base(methodInfo, methodLocalBuilder, aspectWeavingSettings) {
            var @params = method.GetParameters();

            propertyType = @params[0].ParameterType;
        }

        protected override Type PropertyType {
            get {
                return propertyType;
            }
        }

        protected override string PropertyName {
            get {
                return method.Name.Replace("set_", "");
            }
        }

        protected override MethodInfo PropertyMethod {
            get {
                return typeof(PropertyInfo).GetMethod("GetSetMethod", Type.EmptyTypes);
            }
        }
    }
}
