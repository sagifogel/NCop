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
        public PropertyWeaverBuilder(PropertyInfo propertyInfo, Type implementationType, Type contractType, ITypeDefinitionFactory typeDefinitionFactory)
            : base(propertyInfo, implementationType, contractType, typeDefinitionFactory) {
        }

        public IPropertyWeaver Build() {
            var typeDefinition = TypeDefinitionFactory.Resolve();

            return new PropertyDecoratorWeaver(MemberInfo, ImplementationType, ContractType);
        }
    }
}
