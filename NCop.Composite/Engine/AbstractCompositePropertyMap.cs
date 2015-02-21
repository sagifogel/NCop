using NCop.Aspects.Aspects;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public abstract class AbstractCompositePropertyMap : AbstractMemberMap<PropertyInfo>, ICompositePropertyMap
    {
        internal AbstractCompositePropertyMap(Type contractType, Type implementationType, PropertyInfo contractProperty,
            PropertyInfo implementationProperty, IAspectDefinitionCollection aspectDefinitions)
            : base(contractType, implementationType, contractProperty, implementationProperty)
        {
            AspectDefinitions = aspectDefinitions;
            HasAspectDefinitions = aspectDefinitions.IsNotNullOrEmpty();
        }

        public bool HasAspectDefinitions { get; private set; }

        public IAspectDefinitionCollection AspectDefinitions { get; private set; }

        public abstract IPropertyWeaverBuilder Accept(ICompositePropertyMapVisitor visitor);
    }
}