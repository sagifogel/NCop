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
        public PropertyDecoratorWeaver(PropertyInfo propertyInfo, IPropertyWeavingSettings weavingSettings)
            : base(propertyInfo, weavingSettings) {
        }

        public override IMethodWeaver GetGetMethod() {
            if (CanRead) {
                var getMethodImpl = propertyInfo.GetGetMethod();
                var weavingSettings = new MethodWeavingSettings(ContractType, TypeDefinition);

                return new GetPropertyDecoratorWeaver(getMethodImpl, weavingSettings);
            }

            return null;
        }

        public override IMethodWeaver GetSetMethod() {
            if (CanWrite) {
                var setMethodImpl = propertyInfo.GetSetMethod();
                var weavingSettings = new MethodWeavingSettings(ContractType, TypeDefinition);

                return new SetPropertyDecoratorWeaver(setMethodImpl, weavingSettings);
            }

            return null;
        }
    }
}
