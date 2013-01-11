using NCop.Core.Weaving;
using NCop.Core.Weaving.Responsibility;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving.Responsibility
{
    public class AspectPipelineMethodWeaver : IMethodWeaverMatcher
    {
        private IMethodWeaverHandler _handler = null;
        private ITypeDefinition _typeDefinition = null;

        public AspectPipelineMethodWeaver(Type type, ITypeDefinition typeDefinition) {
            _typeDefinition = typeDefinition;
            _handler = new AspectMethodWeaverHandler(type, typeDefinition);

            _handler.SetNextHandler(new MethodDecoratorWeaverHandler(type, typeDefinition))
                    .SetNextHandler(NullObjectMethdodWeaverHanler.Instance);
        }

        public IMethodWeaver Handle(MethodInfo methodInfo) {
            return _handler.Handle(methodInfo);
        }
    }
}
