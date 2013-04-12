using NCop.Aspects.Weaving.Responsibility;
using NCop.Core.Weaving;
using NCop.Core.Weaving.Responsibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Weaving
{
    public class MethodWeaverBuilder : IMethodWeaverBuilder
    {
        private Type _type = null;
        private MethodInfo _methodInfo = null;
        private ITypeDefinitionFactory _typeDefinitionFactory = null;

        public MethodWeaverBuilder(MethodInfo methodInfo, Type type, ITypeDefinitionFactory typeDefinitionFactory) {
            _type = type;
            _methodInfo = methodInfo;
            _typeDefinitionFactory = typeDefinitionFactory;
        }

        public IMethodWeaver Build() {
            var typeDefinition = _typeDefinitionFactory.Resolve();
            var methodWeaver = new MethodDecoratorWeaver(_methodInfo, _type);
            // TODO: change to new AspectPipelineMethodWeaver(_type).Handle(_methodInfo, typeDefinition);

            return new CompositeMethodWeaver(_methodInfo, _type, methodWeaver.MethodDefintionWeaver, new[] { methodWeaver });
        }
    }
}
