using NCop.Aspects.Aspects;
using System;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public class CompositeGetPropertyMap : AbstractCompositeFragmentPropertyMap, ICompositeGetPropertyMap
    {
        internal CompositeGetPropertyMap(Type contractType, Type implementationType, PropertyInfo contractProperty, PropertyInfo implementationProperty, IAspectDefinitionCollection aspectDefinitions)
            : base(contractType, implementationType, contractProperty, implementationProperty, aspectDefinitions) {
            FragmentMethod = contractProperty.GetGetMethod();
        }

        public override void Accept(ICompositePropertyMapVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
