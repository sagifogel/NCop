using System;
using System.Reflection;

namespace NCop.Core
{
    public class PropertyMap : MemberMap<PropertyInfo>, IPropertyMap
    {
        public PropertyMap(Type serviceType, Type concreteType, PropertyInfo contractProperty, PropertyInfo implementationProperty)
            : base(serviceType, concreteType, contractProperty, implementationProperty) {
        }
    }
}