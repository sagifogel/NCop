using NCop.Aspects.Aspects;
using System;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public abstract class AbstractCompositeFragmentPropertyMap : AbstractCompositeMap<PropertyInfo>, ICompositePropertyFragmentMap
    {
        internal AbstractCompositeFragmentPropertyMap(Type contractType, Type implementationType, PropertyInfo contractProperty, PropertyInfo implementationProperty, IAspectDefinitionCollection aspectDefinitions)
            : base(contractType, implementationType, contractProperty, implementationProperty, aspectDefinitions) {
        }

        public abstract void Accept(ICompositePropertyMapVisitor visitor);
    }
}