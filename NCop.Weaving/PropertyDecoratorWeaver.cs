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
        private PropertyInfo propertyInfo = null;

        public PropertyDecoratorWeaver(PropertyInfo propertyInfo, Type implementationType, Type contractType) {
            this.contractType = contractType;
            this.propertyInfo = propertyInfo;
            this.implementationType = implementationType;
        }

        public IMethodWeaver GetGetMethod() {
            if (propertyInfo.CanRead) {
                var getMethod = propertyInfo.GetGetMethod();

                return new PropertyGetDecoratorWeaver(getMethod, implementationType, contractType);
            }

            return null;
        }

        public IMethodWeaver GetSetMethod() {
            if (propertyInfo.CanWrite) {
                var getMethod = propertyInfo.GetSetMethod();

                return new PropertySetDecoratorWeaver(getMethod, implementationType, contractType);
            }

            return null;
        }

        public bool CanRead {
            get {
                return propertyInfo.CanRead;     
            }
        }

        public bool CanWrite {
            get {
                return propertyInfo.CanWrite;
            }
        }
    }
}
