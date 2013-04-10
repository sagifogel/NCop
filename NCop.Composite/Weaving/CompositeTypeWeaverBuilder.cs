using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Responsibility;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.Core.Mixin;
using NCop.Core.Weaving;
using NCop.Mixins.Engine;
using NCop.Mixins.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Composite.Weaving
{
    public class CompositeTypeWeaverBuilder : ITypeWeaverBuilder
    {
        private readonly MixinsTypeWeaverBuilder _builder = null;

        public CompositeTypeWeaverBuilder(Type type) {
            var mixinsMap = new MixinsMap(type);
            var typeDefinitionWeaver = new MixinsTypeDefinitionWeaver(type, mixinsMap);
            var typeDefinition = typeDefinitionWeaver.Weave();
            var aspectMap = new AspectsMap(type);
            
            _builder = new MixinsTypeWeaverBuilder(type);

            mixinsMap.ForEach(map => {
                _builder.Add(map);
            });

            aspectMap.SelectMany(map => map.AspectTypes)
                     .ForEach(aspect => {
                         aspect.GetMethods()
                               .ForEach(methodInfo => {
                                   var methodBuilder = new MethodWeaverBuilder(methodInfo, aspect, typeDefinition);
                                   
                                   _builder.Add(methodBuilder.Build());
                               });
                     });
        }

        public ITypeWeaver Build() {
            return _builder.Build();
        }
    }
}
