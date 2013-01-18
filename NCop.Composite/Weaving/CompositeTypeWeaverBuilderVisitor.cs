using NCop.Aspects.Weaving.Responsibility;
using NCop.Core;
using NCop.Core.Weaving;
using NCop.Mixins.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Weaving
{
    public class CompositeTypeWeaverBuilderVisitor : ITypeWeaverBuilderVisitor
    {
        private ITypeDefinition _typeDefinition = null;
        private readonly MixinsTypeWeaverBuilder _builder = null;
        private readonly List<IMethodWeaverHandler> _methodHandlers = null;
        private readonly MixinsTypeDefinitionWeaver _typeDefinitionWeaver = null;

        public CompositeTypeWeaverBuilderVisitor(Type type) {
            _builder = new MixinsTypeWeaverBuilder(type);
            _typeDefinitionWeaver = new MixinsTypeDefinitionWeaver(null);
            _methodHandlers.Add(new AspectPipelineMethodWeaver(type));
        }

        public void Visit(Type type) {
            _typeDefinition = _typeDefinitionWeaver.Weave();

            _builder.AddMixinTypeMap(null);
        }

        public void Visit(MethodInfo method) {
            var hanlders = _methodHandlers.Select(handler => handler.Handle(method, _typeDefinition));
            var compositeMethodWeaver = new CompositeMethodWeaver(method, hanlders);

            _builder.AddMethodWeaver(compositeMethodWeaver);
        }

        public void Visit(PropertyInfo property) {
            throw new NotImplementedException();
        }
    }
}
