using NCop.Core;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class AspectPropertyMap : AbstractMemberMap<PropertyInfo>, IAspectPropertyMap
    {
        public AspectPropertyMap(Type contractType, Type implementationType, PropertyInfo contractProperty, PropertyInfo implementationProperty, PropertyInfo aspectProperty)
            : base(contractType, implementationType, contractProperty, implementationProperty) {
            AddIfNotNull(() => aspectProperty);
            AspectGetProperty = aspectProperty.GetGetMethod();
            AspectSetProperty = aspectProperty.GetSetMethod();
            IsPartial = AspectGetProperty.IsNull() || AspectSetProperty.IsNull();
        }

        public bool IsPartial { get; private set; }
        
        public MethodInfo AspectGetProperty { get; private set; }
        
        public MethodInfo AspectSetProperty { get; private set; }
    }
}
