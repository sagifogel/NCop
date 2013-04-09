using NCop.Aspects.Weaving.Responsibility;
using NCop.Core.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Weaving
{
    public class MethodWeaverBuilder : IBuilder<IMethodWeaver>
    {
        private Type _type = null;
        private MethodInfo _methodInfo = null;
        private ITypeDefinition _typeDefinition = null;

        public MethodWeaverBuilder(MethodInfo methodInfo, Type type, ITypeDefinition typeDefinition) {
            _type = type;
            _methodInfo = methodInfo;
            _typeDefinition = typeDefinition;
        }

        public IMethodWeaver Build() {
            var methodWeaver = new AspectPipelineMethodWeaver(_type).Handle(_methodInfo, _typeDefinition);

            return new CompositeMethodWeaver(_methodInfo, _type, methodWeaver.MethodDefintionWeaver, new[] { methodWeaver });
        }
    }
}
