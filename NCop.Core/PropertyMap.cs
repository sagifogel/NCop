using System;
using System.Reflection;

namespace NCop.Core
{
	public class PropertyMap : MemberMap<PropertyInfo>, IPropertyMap
	{
		public PropertyMap(Type contractType, Type implementationType, PropertyInfo contractProperty, PropertyInfo implementationProperty)
			: base(contractType, implementationType, contractProperty, implementationProperty) {
		}
	}
}