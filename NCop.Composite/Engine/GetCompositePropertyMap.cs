using NCop.Aspects.Aspects;
using NCop.Weaving;
using System;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public class GetCompositePropertyMap : AbstractCompositePropertyMap, ICompositeGetPropertyMap
    {
        internal GetCompositePropertyMap(Type contractType, Type implementationType, PropertyInfo contractProperty, PropertyInfo implementationProperty, IAspectDefinitionCollection aspectDefinitions)
            : base(contractType, implementationType, contractProperty, implementationProperty, aspectDefinitions) {
        }

        public override ICompositeMethodWeaverBuilderFactory Accept(ICompositePropertyMapVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
