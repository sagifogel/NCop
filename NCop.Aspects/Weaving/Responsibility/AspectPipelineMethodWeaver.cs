using NCop.Core.Weaving;
using NCop.Core.Weaving.Responsibility;
using System;
using System.Reflection;

namespace NCop.Aspects.Weaving.Responsibility
{
    public class AspectPipelineMethodWeaver : IMethodWeaverHandler
    {
        private readonly IMethodWeaverChainer _handler = null;

        public AspectPipelineMethodWeaver(Type type) {
            _handler = new AspectMethodWeaverHandler(type);

            _handler.SetNextHandler(new MethodDecoratorWeaverHandler(type));
        }

		public IMethodWeaver Handle(MethodInfo methodInfo, ITypeDefinition typeDefinition) {
            return _handler.Handle(methodInfo, typeDefinition);
        }
    }
}
