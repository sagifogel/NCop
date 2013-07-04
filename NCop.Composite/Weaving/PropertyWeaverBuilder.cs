using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Weaving
{
    public class PropertyWeaverBuilder : AbstractWeaverBuilder<PropertyInfo>, IPropertyWeaverBuilder
    {
        public PropertyWeaverBuilder(PropertyInfo propertyInfoImpl, Type implementationType, Type contractType, ITypeDefinitionFactory typeDefinitionFactory)
            : base(propertyInfoImpl, implementationType, contractType, typeDefinitionFactory) {
        }

        public IPropertyWeaver Build() {
            var typeDefinition = TypeDefinitionFactory.Resolve();

            return new PropertyDecoratorWeaver(MemberInfoImpl, ImplementationType, ContractType);
        }
    }
}
