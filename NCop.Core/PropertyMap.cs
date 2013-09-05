using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core
{
	public class PropertyMap : MemberMap<PropertyInfo>
	{
		public PropertyMap(Type contractType, Type implementationType, PropertyInfo contractProperty, PropertyInfo implementationProperty)
			: base(contractType, implementationType, contractProperty, implementationProperty) {
		}
	}
}