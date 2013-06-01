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
        private Type ContractType = null;
        private Type ImplementationType = null;
        private PropertyInfo MemberInfo = null;

        public PropertyDecoratorWeaver(PropertyInfo memberInfo, Type implementationType, Type contractType) {
            MemberInfo = memberInfo;
            ContractType = contractType;
            ImplementationType = implementationType;
        }

        public IPropertyGetWeaver PropertyGetWeaver {
            get { throw new NotImplementedException(); }
        }

        public IPropertySetWeaver PropertySetWeaver {
            get { throw new NotImplementedException(); }
        }
    }
}
