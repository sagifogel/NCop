using NCop.Aspects.Weaving.Responsibility;
using NCop.Composite.Engine;
using NCop.Weaving;
using NCop.Weaving.Responsibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Weaving
{
    public class CompositeMethodWeaverBuilder : AbstractWeaverBuilder<MethodInfo>, IMethodWeaverBuilder
    {
        private readonly ICompositeMethodMap compositeMethodMap = null;

        public CompositeMethodWeaverBuilder(ICompositeMethodMap compositeMethodMap, ITypeDefinitionFactory typeDefinitionFactory)
            : base(compositeMethodMap.ImplementationMember, compositeMethodMap.ImplementationType, compositeMethodMap.ContractType, typeDefinitionFactory) {
            this.compositeMethodMap = compositeMethodMap;
        }

        public IMethodWeaver Build() {
            var typeDefinition = TypeDefinitionFactory.Resolve();

            if (compositeMethodMap.HasAspectDefinitions) {
                return new CompositeMethodWeaver(compositeMethodMap.AspectDefinitions, MemberInfoImpl, ImplementationType, ContractType);
            }

            return new MethodDecoratorWeaver(MemberInfoImpl, ImplementationType, ContractType);
        }
    }
}
