using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    internal class AspectArgsGetPropertyWeaver : AbstractAspectArgsPropertyWeaver
    {
        internal AspectArgsGetPropertyWeaver(LocalBuilder methodLocalBuilder, IAspectPropertyMethodWeavingSettings aspectWeavingSettings)
            : base(methodLocalBuilder, aspectWeavingSettings) {
        }

        protected override MethodInfo PropertyMethod {
            get {
                return typeof(PropertyInfo).GetMethod("GetGetMethod", Type.EmptyTypes);
            }
        }
    }
}
