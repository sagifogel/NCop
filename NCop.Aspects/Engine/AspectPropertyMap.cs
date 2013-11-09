using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class AspectPropertyMap : AbstractMemberMap<PropertyInfo>, IAspectPropertyMap
    {
        public AspectPropertyMap(Type contractType, Type implementationType, PropertyInfo contractProperty, PropertyInfo implementationProperty, PropertyInfo aspectProperty)
            : base(contractType, implementationType, contractProperty, implementationProperty) {
            AspectProperty = aspectProperty;
            AddIfNotNull(() => aspectProperty);
        }

        public PropertyInfo AspectProperty { get; private set; }
    }
}
