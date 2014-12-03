using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Weaving
{
    public class PropertyWeavingSettings : IPropertyWeavingSettings
    {
        public PropertyWeavingSettings(PropertyInfo propertyInfoImpl, PropertyInfo propertyInfoContract, Type implementationType, Type contractType, ITypeDefinition typeDefinition) {
            ContractType = contractType;
            TypeDefinition = typeDefinition;
            PropertyInfoImpl = propertyInfoImpl;
            ImplementationType = implementationType;
            PropertyInfoContract = propertyInfoContract;
        }

        public Type ContractType { get; private set; }
        public Type ImplementationType { get; private set; }
        public PropertyInfo PropertyInfoImpl { get; private set; }
        public ITypeDefinition TypeDefinition { get; private set; }
        public PropertyInfo PropertyInfoContract { get; private set; }
    }
}
