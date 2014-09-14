using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class PropertyDecoratorWeaver : IPropertyWeaver
    {
        private readonly Type contractType = null;
        private readonly Type implementationType = null;
		private readonly PropertyInfo propertyInfoImpl = null;
		private readonly ITypeDefinition typeDefinition = null;

        public PropertyDecoratorWeaver(PropertyInfo propertyInfoImpl, Type implementationType, Type contractType, ITypeDefinition typeDefinition) {
            this.contractType = contractType;
			this.typeDefinition = typeDefinition;
			this.propertyInfoImpl = propertyInfoImpl;
            this.implementationType = implementationType;
        }

        public IMethodWeaver GetGetMethod() {
            if (propertyInfoImpl.CanRead) {
                var getMethodImpl = propertyInfoImpl.GetGetMethod();
				var weavingSettings = new WeavingSettings(getMethodImpl, implementationType, contractType, typeDefinition);
				
				return new PropertyGetDecoratorWeaver(weavingSettings);
            }

            return null;
        }

        public IMethodWeaver GetSetMethod() {
            if (propertyInfoImpl.CanWrite) {
                var setMethodImpl = propertyInfoImpl.GetSetMethod();
				var weavingSettings = new WeavingSettings(setMethodImpl, implementationType, contractType, typeDefinition);

				return new PropertySetDecoratorWeaver(weavingSettings);
            }

            return null;
        }

        public bool CanRead {
            get {
                return propertyInfoImpl.CanRead;     
            }
        }

        public bool CanWrite {
            get {
                return propertyInfoImpl.CanWrite;
            }
        }
    }
}
