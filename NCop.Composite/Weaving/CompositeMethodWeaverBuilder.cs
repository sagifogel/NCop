using NCop.Composite.Engine;
using NCop.Weaving;
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

        public CompositeMethodWeaverBuilder(ICompositeMethodMap compositeMethodMap, ITypeDefinition typeDefinition)
            : base(compositeMethodMap.ImplementationMember, compositeMethodMap.ImplementationType, compositeMethodMap.ContractType, typeDefinition) {
            this.compositeMethodMap = compositeMethodMap;
        }

        public IMethodWeaver Build() {
			var weavingSettings = new WeavingSettings(MemberInfoImpl, ImplementationType, ContractType, TypeDefinition);
            
			if (compositeMethodMap.HasAspectDefinitions) {
				return new CompositeMethodWeaver(compositeMethodMap.AspectDefinitions, weavingSettings);
            }

			return new MethodDecoratorWeaver(weavingSettings);
        }
    }
}
