using NCop.Aspects.Aspects;
using System;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public class GetCompositePropertyMap : AbstractCompositeFragmentPropertyMap, ICompositeGetPropertyMap
    {
        internal GetCompositePropertyMap(Type contractType, Type implementationType, PropertyInfo contractProperty, PropertyInfo implementationProperty, IAspectDefinitionCollection aspectDefinitions)
            : base(contractType, implementationType, contractProperty, implementationProperty, aspectDefinitions) {
        }

        public override void Accept(ICompositePropertyMapVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
