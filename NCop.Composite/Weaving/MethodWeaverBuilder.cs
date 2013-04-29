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
        private Type type = null;
        private MethodInfo methodInfo = null;
        private ITypeDefinitionFactory typeDefinitionFactory = null;

        public MethodWeaverBuilder(MethodInfo methodInfo, Type type, ITypeDefinitionFactory typeDefinitionFactory) {
            this.type = type;
            this.methodInfo = methodInfo;
            this.typeDefinitionFactory = typeDefinitionFactory;
        }

        public IMethodWeaver Build() {
            var typeDefinition = typeDefinitionFactory.Resolve();
            var methodWeaver = new MethodDecoratorWeaver(methodInfo, type);
            // TODO: change to new AspectPipelineMethodWeaver(_type).Handle(_methodInfo, typeDefinition);

            return new CompositeMethodWeaver(methodInfo, type, methodWeaver.MethodDefintionWeaver, new[] { methodWeaver });
        }
    }
}
