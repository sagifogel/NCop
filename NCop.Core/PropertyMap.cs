using NCop.Core.Exceptions;
using NCop.Core.Properties;
using System;
using NCop.Core.Extensions;
using System.Reflection;

namespace NCop.Core
{
    public class PropertyMap : MemberMap<PropertyInfo>, IPropertyMap
    {
        public PropertyMap(Type contractType, Type implementationType, PropertyInfo contractProperty, PropertyInfo implementationProperty)
            : base(contractType, implementationType, contractProperty, implementationProperty) {
            ValidateProperties();
        }

        private void ValidateProperties() {
            if (ContractMember.CanRead != ImplementationMember.CanRead ||
                ContractMember.CanWrite != ImplementationMember.CanWrite) {
                throw new PropertyAccessorsMismatchException(Resources.PropertiesAccessorsMismatach.Fmt(ContractMember.Name, ContractType.FullName, ImplementationType.FullName));
            }
        }
    }
}