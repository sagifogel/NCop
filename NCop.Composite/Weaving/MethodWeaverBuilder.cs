using NCop.Aspects.Weaving.Responsibility;
using NCop.Weaving;
using NCop.Weaving.Responsibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Weaving
{
    public class MethodWeaverBuilder : AbstractWeaverBuilder<MethodInfo>, IMethodWeaverBuilder
    {
        public MethodWeaverBuilder(MethodInfo methodInfoImpl, Type implementationType, Type contractType, ITypeDefinitionFactory typeDefinitionFactory)
            : base(methodInfoImpl, implementationType, contractType, typeDefinitionFactory) {
        }

        public IMethodWeaver Build() {
            var typeDefinition = TypeDefinitionFactory.Resolve();
            var methodWeaver = new MethodDecoratorWeaver(MemberInfoImpl, ImplementationType, ContractType);
            
            return new CompositeMethodWeaver(MemberInfoImpl, ImplementationType, ContractType, methodWeaver.MethodDefintionWeaver, new[] { methodWeaver });
        }
    }
}
