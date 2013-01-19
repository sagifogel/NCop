using NCop.Aspects.Weaving.Responsibility;
using NCop.Core.Extensions;
using NCop.Core.Weaving;
using NCop.Mixins.Engine;
using NCop.Mixins.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Composite.Weaving
{
    public class CompositeTypeWeaverBuilderVisitor : AbstractTypeWeaverBuilderVisitor
    {
        private ITypeDefinition _typeDefinition = null;
        private IMethodWeaverHandler _methodWeaverHanlder = null;
        private readonly List<IMethodWeaverHandler> _methodHandlers = null;

        public CompositeTypeWeaverBuilderVisitor(Type type)
            : base(type) {
            _methodHandlers = new List<IMethodWeaverHandler>();
        }

        protected override ITypeWeaverBuilder GetTypeWeaverBuilder(Type type) {
            return new MixinsTypeWeaverBuilder(type);
        }

        public override void Visit(Type type) {
            var mixinsMap = new MixinsMap(type);
            var typeDefinitionWeaver = new MixinsTypeDefinitionWeaver(mixinsMap);

            _methodWeaverHanlder = new AspectPipelineMethodWeaver(type);
            //_typeDefinition = typeDefinitionWeaver.Weave();
            _methodHandlers.Add(_methodWeaverHanlder);

            Builder.AddMixinTypeMap(null);
        }

        public override void Visit(MethodInfo methodInfo) {
            CompositeMethodWeaver compositeMethodWeaver = null;
            var handlers = _methodHandlers.Select(handler => handler.Handle(methodInfo, _typeDefinition));
            var mainWeaver = _methodWeaverHanlder.Handle(methodInfo, _typeDefinition);
            var methodWeavers = new List<IMethodWeaver>() { mainWeaver };
            
            methodWeavers.AddRange(handlers) ;
            compositeMethodWeaver = new CompositeMethodWeaver(methodInfo, Type, mainWeaver.MethodDefintionWeaver, methodWeavers);

            Builder.AddMethodWeaver(compositeMethodWeaver);
        }
    }
}
