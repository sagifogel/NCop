using NCop.Aspects.Weaving.Responsibility;
using NCop.Core;
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
    public class CompositeTypeWeaverBuilderVisitor : ITypeWeaverBuilderVisitor
    {
        private readonly Type _type = null;

        public CompositeTypeWeaverBuilderVisitor(Type type) {
            _type = type;
        }

        public ITypeWeaverBuilder Visit() {
            var mixinsMap = new MixinsMap(_type);
            var builder = new MixinsTypeWeaverBuilder(_type);
            var typeDefinitionWeaver = new MixinsTypeDefinitionWeaver(mixinsMap);
            var typeDefinition = typeDefinitionWeaver.Weave();

            mixinsMap.ForEach(map => {
                builder.AddMixinTypeMap(map);
                new CompositeTypeVisitor(_type, builder, typeDefinition).Visit();
            });

            return builder;
        }

        public class CompositeTypeVisitor : AbstractTypeWeaverBuilderVisitor
        {
            private readonly IMethodWeaverHandler _methodWeaverHanlder = null;
            private readonly List<IMethodWeaverHandler> _methodHandlers = null;

            public CompositeTypeVisitor(Type type, ITypeWeaverBuilder builder, ITypeDefinition typeDefinition)
                : base(type) {
                Builder = builder;
                TypeDefinition = typeDefinition;
                _methodHandlers = new List<IMethodWeaverHandler>();
                _methodWeaverHanlder = new AspectPipelineMethodWeaver(type);
                _methodHandlers.Add(_methodWeaverHanlder);
            }

            public override void Visit(MethodInfo methodInfo) {
                CompositeMethodWeaver compositeMethodWeaver = null;
                var handlers = _methodHandlers.Select(handler => handler.Handle(methodInfo, TypeDefinition));
                var mainWeaver = _methodWeaverHanlder.Handle(methodInfo, TypeDefinition);
                var methodWeavers = new List<IMethodWeaver>() { mainWeaver };

                methodWeavers.AddRange(handlers);
                compositeMethodWeaver = new CompositeMethodWeaver(methodInfo, Type, mainWeaver.MethodDefintionWeaver, methodWeavers);

                Builder.AddMethodWeaver(compositeMethodWeaver);
            }
        }
    }
}
