using NCop.Aspects.Aspects;
using NCop.Core;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public abstract class AbstractCompositeFragmentPropertyMap : AbstractMemberMap<PropertyInfo>, ICompositePropertyFragmentMap
    {
        internal AbstractCompositeFragmentPropertyMap(Type contractType, Type implementationType, PropertyInfo contractProperty, PropertyInfo implementationProperty, IAspectDefinitionCollection aspectDefinitions)
            : base(contractType, implementationType, contractProperty, implementationProperty) {
            AspectDefinitions = aspectDefinitions;
            HasAspectDefinitions = aspectDefinitions.IsNotNullOrEmpty();
        }

        public bool HasAspectDefinitions { get; private set; }

        public IAspectDefinitionCollection AspectDefinitions { get; private set; }

        public abstract ICompositeMethodWeaverBuilderFactory Accept(ICompositePropertyMapVisitor visitor);
    }
}