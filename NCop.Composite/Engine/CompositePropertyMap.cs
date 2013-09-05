using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Engine
{
	public class CompositePropertyMap : AbstractCompositeMemberMap<PropertyInfo>, ICompositePropertyMap
	{
		public CompositePropertyMap(Type contractType, Type implementationType, PropertyInfo contractProperty, PropertyInfo implementationProperty, PropertyInfo compositeProperty)
			: base(contractType, implementationType, contractProperty, implementationProperty, compositeProperty) {
			}
	}
}
