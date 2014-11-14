using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class PropertyDecoratorWeaver : AbstractPropertyWeaver
    {
        public PropertyDecoratorWeaver(IPropertyWeavingSettings weavingSettings)
            : base(weavingSettings) {
        }

        public override IMethodWeaver GetGetMethod() {
            if (CanRead) {
                var getMethodImpl = PropertyInfoImpl.GetGetMethod();
                var weavingSettings = new MethodWeavingSettings(getMethodImpl, ImplementationType, ContractType, TypeDefinition);

                return new GetPropertyDecoratorWeaver(weavingSettings);
            }

            return null;
        }

        public override IMethodWeaver GetSetMethod() {
            if (CanWrite) {
                var setMethodImpl = PropertyInfoImpl.GetSetMethod();
                var weavingSettings = new MethodWeavingSettings(setMethodImpl, ImplementationType, ContractType, TypeDefinition);

                return new SetPropertyDecoratorWeaver(weavingSettings);
            }

            return null;
        }
    }
}
