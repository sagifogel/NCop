using NCop.Aspects.Aspects;
using NCop.Composite.Engine;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Weaving
{
    public class CompositePropertyWeaverBuilder : AbstractWeaverBuilder<PropertyInfo>, IPropertyWeaverBuilder
    {
        private readonly ICompositePropertyMap compositePropertyMap = null;

        public CompositePropertyWeaverBuilder(ICompositePropertyMap compositePropertyMap, ITypeDefinitionFactory typeDefinitionFactory)
            : base(compositePropertyMap.ImplementationMember, compositePropertyMap.ImplementationType, compositePropertyMap.ContractType, typeDefinitionFactory) {
            this.compositePropertyMap = compositePropertyMap;
        }

        public IPropertyWeaver Build() {
            var typeDefinition = TypeDefinitionFactory.Resolve();

            if (compositePropertyMap.HasAspectDefinitions) {
                return new PropertyDecoratorWeaver(MemberInfoImpl, ImplementationType, ContractType);
            }

            return new PropertyDecoratorWeaver(MemberInfoImpl, ImplementationType, ContractType);
        }
    }
}
