using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    internal class AspectArgsGetPropertyWeaver : AbstractAspectPropertyArgsWeaver
    {
        internal AspectArgsGetPropertyWeaver(MethodInfo methodInfo, LocalBuilder methodLocalBuilder, IAspectWeavingSettings aspectWeavingSettings)
            : base(methodInfo, methodLocalBuilder, aspectWeavingSettings) {
        }

        protected override string PropertyName {
            get {
                return methodInfo.Name.Replace("get_", "");
            }
        }

        protected override MethodInfo PropertyMethod {
            get {
                return typeof(PropertyInfo).GetMethod("GetGetMethod", Type.EmptyTypes);
            }
        }
    }
}
