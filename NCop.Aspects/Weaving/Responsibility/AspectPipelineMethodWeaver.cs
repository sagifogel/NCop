using NCop.Core.Weaving;
using NCop.Core.Weaving.Responsibility;
using System;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving.Responsibility
{
    public class AspectPipelineMethodWeaver : IMethodWeaver
    {
        private IMethodWeaver _methodWeaver = null;
        private IMethodBuilderHandler _handler = null;
        private ITypeDefinition _typeDefinition = null;

        public AspectPipelineMethodWeaver(Type type, ITypeDefinition typeDefinition) {
            _typeDefinition = typeDefinition;
            _handler = new MethodDecoratorWeaverHandler(type, typeDefinition);

            _handler.SetNextHandler(NullObjectHanler.Instance)
                    .SetNextHandler(NullObjectHanler.Instance);
        }

        public MethodBuilder DefineMethod(TypeBuilder typeBuilder) {
            _methodWeaver = _handler.Handle(_typeDefinition);

            return _methodWeaver.DefineMethod(typeBuilder);
        }

        public ILGenerator WeaveMethodScope(ILGenerator ilGenerator) {
            return _methodWeaver.WeaveMethodScope(ilGenerator);
        }

        public void WeaveEndMethod(ILGenerator ilGenerator) {
            _methodWeaver.WeaveEndMethod(ilGenerator);
        }
    }
}
