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
    public class CompositeTypeWeaverBuilderVisitor : AbstractTypeWeaverBuilderVisitor
    {
        private ITypeDefinition _typeDefinition = null;
        private readonly List<IMethodWeaverHandler> _methodHandlers = null;

        public CompositeTypeWeaverBuilderVisitor(Type type)
            : base(type) {
            _methodHandlers = new List<IMethodWeaverHandler>();
        }

        protected override ITypeWeaverBuilder GetTypeWeaverBuilder(Type type) {
            return new MixinsTypeWeaverBuilder(type);
        }

        public override void Visit(Type type) {
            var typeDefinitionWeaver = new MixinsTypeDefinitionWeaver(null);
            
            _typeDefinition = typeDefinitionWeaver.Weave();
            _methodHandlers.Add(new AspectPipelineMethodWeaver(type));

            Builder.AddMixinTypeMap(null);
        }

        public override void Visit(MethodInfo method) {
            var hanlders = _methodHandlers.Select(handler => handler.Handle(method, _typeDefinition));
            var compositeMethodWeaver = new CompositeMethodWeaver(method, hanlders);

            Builder.AddMethodWeaver(compositeMethodWeaver);
        }
    }
}
