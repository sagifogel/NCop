using NCop.Aspects.Aspects;
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
    public class CompositeTypeWeaverBuilderProvider : ITypeWeaverBuilderProvider
    {
        private readonly ITypeWeaverBuilder _builder = null;

        public CompositeTypeWeaverBuilderProvider(Type type) {
            var mixinsMap = new MixinsMap(type);
            var typeDefinitionWeaver = new MixinsTypeDefinitionWeaver(mixinsMap);
            var typeDefinition = typeDefinitionWeaver.Weave();
            var aspectMap = new AspectsMap(type);

            _builder = new MixinsTypeWeaverBuilder(type);

            mixinsMap.ForEach(map => {
                _builder.AddMixinTypeMap(map);
            });

            aspectMap.SelectMany(map => map.AspectTypes)
                     .ForEach(aspect => {
                         new CompositeTypeVisitor(aspect, _builder, typeDefinition).Visit();
                     });
        }

        public ITypeWeaverBuilder Builder {
            get {
                return _builder;
            }
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
