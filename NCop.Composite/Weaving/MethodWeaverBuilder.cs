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
    public class MethodWeaverBuilder : IMethodWeaverBuilder
    {
        private Type contractType = null; 
        private MethodInfo methodInfo = null;
        private Type implementationType = null;
        private ITypeDefinitionFactory typeDefinitionFactory = null;

        public MethodWeaverBuilder(MethodInfo methodInfo, Type implementationType, Type contractType, ITypeDefinitionFactory typeDefinitionFactory) {
            this.methodInfo = methodInfo;
            this.contractType = contractType;
            this.implementationType = implementationType;
            this.typeDefinitionFactory = typeDefinitionFactory;
        }

        public IMethodWeaver Build() {
            var typeDefinition = typeDefinitionFactory.Resolve();
            var methodWeaver = new MethodDecoratorWeaver(methodInfo, implementationType, contractType);
            // TODO: change to new AspectPipelineMethodWeaver(_type).Handle(_methodInfo, typeDefinition);

            return new CompositeMethodWeaver(methodInfo, implementationType, contractType, methodWeaver.MethodDefintionWeaver, new[] { methodWeaver });
        }
    }
}
