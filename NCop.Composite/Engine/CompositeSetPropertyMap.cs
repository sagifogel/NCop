using NCop.Aspects.Aspects;
using System;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public class CompositeSetPropertyMap : AbstractCompositeFragmentPropertyMap, ICompositeSetPropertyMap
    {
        internal CompositeSetPropertyMap(Type contractType, Type implementationType, PropertyInfo contractProperty, PropertyInfo implementationProperty, IAspectDefinitionCollection aspectDefinitions)
            : base(contractType, implementationType, contractProperty, implementationProperty, aspectDefinitions) {
            FragmentMethod = contractProperty.GetSetMethod();
        }

        public override void Accept(ICompositePropertyMapVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
