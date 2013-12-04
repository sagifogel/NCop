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

        public CompositePropertyWeaverBuilder(ICompositePropertyMap compositePropertyMap, ITypeDefinition typeDefinition)
            : base(compositePropertyMap.ImplementationMember, compositePropertyMap.ImplementationType, compositePropertyMap.ContractType, typeDefinition) {
            this.compositePropertyMap = compositePropertyMap;
        }

        public IPropertyWeaver Build() {
            if (compositePropertyMap.HasAspectDefinitions) {

				return new PropertyDecoratorWeaver(MemberInfoImpl, ImplementationType, ContractType, TypeDefinition);
            }

			return new PropertyDecoratorWeaver(MemberInfoImpl, ImplementationType, ContractType, TypeDefinition);
        }
    }
}
