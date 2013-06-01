using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Weaving
{
    public class PropertyWeaverBuilder : AbstractWeaverBuilder<PropertyInfo, IPropertyWeaver>, IPropertyWeaverBuilder
    {
         public PropertyWeaverBuilder(PropertyInfo propertyInfo, Type implementationType, Type contractType, ITypeDefinitionFactory typeDefinitionFactory)
            : base(propertyInfo, implementationType, contractType, typeDefinitionFactory) {
        }

         public override IPropertyWeaver Build() {
             var typeDefinition = TypeDefinitionFactory.Resolve();
             var methodWeaver = new PropertyDecoratorWeaver(MemberInfo, ImplementationType, ContractType);
             // TODO: change to new AspectPipelinePropertyWeaver(_type).Handle(_methodInfo, typeDefinition);

             return null;// new CompositeMethodWeaver(MemberInfo, ImplementationType, ContractType, methodWeaver.MethodDefintionWeaver, new[] { methodWeaver });
        }
    }
}
