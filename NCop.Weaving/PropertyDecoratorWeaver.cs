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
        private Type contractType = null;
        private Type implementationType = null;
        private PropertyInfo propertyInfoImpl = null;

        public PropertyDecoratorWeaver(PropertyInfo propertyInfoImpl, Type implementationType, Type contractType) {
            this.contractType = contractType;
            this.propertyInfoImpl = propertyInfoImpl;
            this.implementationType = implementationType;
        }

        public IMethodWeaver GetGetMethod() {
            if (propertyInfoImpl.CanRead) {
                var getMethodImpl = propertyInfoImpl.GetGetMethod();

                return new PropertyGetDecoratorWeaver(getMethodImpl, implementationType, contractType);
            }

            return null;
        }

        public IMethodWeaver GetSetMethod() {
            if (propertyInfoImpl.CanWrite) {
                var setMethodImpl = propertyInfoImpl.GetSetMethod();

                return new PropertySetDecoratorWeaver(setMethodImpl, implementationType, contractType);
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
