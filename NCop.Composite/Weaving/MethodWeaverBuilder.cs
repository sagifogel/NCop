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
    public class MethodWeaverBuilder : AbstractWeaverBuilder<MethodInfo, IMethodWeaver>, IMethodWeaverBuilder
    {
        public MethodWeaverBuilder(MethodInfo methodInfo, Type implementationType, Type contractType, ITypeDefinitionFactory typeDefinitionFactory)
            : base(methodInfo, implementationType, contractType, typeDefinitionFactory) {
        }

        public override IMethodWeaver Build() {
            var typeDefinition = TypeDefinitionFactory.Resolve();
            var methodWeaver = new MethodDecoratorWeaver(MemberInfo, ImplementationType, ContractType);
            // TODO: change to new AspectPipelineMethodWeaver(_type).Handle(_methodInfo, typeDefinition);

            return new CompositeMethodWeaver(MemberInfo, ImplementationType, ContractType, methodWeaver.MethodDefintionWeaver, new[] { methodWeaver });
        }
    }
}
