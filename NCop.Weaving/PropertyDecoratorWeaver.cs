using System;
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
		private IPropertyGetWeaver getWeaver = null;
		private IPropertySetWeaver setWeaver = null;

		public PropertyDecoratorWeaver(PropertyInfo propertyInfo, Type implementationType, Type contractType) {
			this.propertyInfo = propertyInfo;
            this.contractType = contractType;
            this.implementationType = implementationType;

			if (propertyInfo.CanRead) {
				getWeaver = new PropertyGetDecoratorWeaver(propertyInfo.GetGetMethod(), implementationType, contractType);
			}

			if (propertyInfo.CanWrite) {
				setWeaver = new PropertySetDecoratorWeaver(propertyInfo.GetSetMethod(), implementationType, contractType);
			}
        }

        public IPropertyGetWeaver PropertyGetWeaver {
            get { 
				return getWeaver; 
			}
        }

        public IPropertySetWeaver PropertySetWeaver {
            get {
				return setWeaver;
			}
        }
    }
}
