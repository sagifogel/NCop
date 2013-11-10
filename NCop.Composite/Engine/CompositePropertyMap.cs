using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Core;
using NCop.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Engine
{
    public class CompositePropertyMap : AbstractMemberMap<PropertyInfo>, ICompositePropertyMap
    {
        public CompositePropertyMap(Type contractType, Type implementationType, PropertyInfo contractProperty, PropertyInfo implementationProperty, IEnumerable<IAspectDefinition> aspectDefinitions)
            : base(contractType, implementationType, contractProperty, implementationProperty) {
            AspectDefinitions = aspectDefinitions;
            HasAspectDefinitions = aspectDefinitions.IsNotNullOrEmpty();
        }

        public bool HasAspectDefinitions { get; private set; }
        public IEnumerable<IAspectDefinition> AspectDefinitions { get; private set; }
    }
}
