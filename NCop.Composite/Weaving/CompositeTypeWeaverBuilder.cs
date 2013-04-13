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
            var aspectMap = new AspectsMap(type);
            var factory = new MixinsTypeDefinitionWeaver(type, mixinsMap);

            aspectMap.Join(mixinsMap,
                           (aspect) => aspect.Contract,
                           (mixin) => mixin.Contract,
                           (a, m) => Tuple.Create(a, m));

            _builder = new MixinsTypeWeaverBuilder(type, factory);

            mixinsMap.ForEach(map => {
                _builder.Add(map);
            });

            aspectMap.SelectMany(map => map.AspectTypes)
                     .ForEach(aspect => {
                         aspect.GetMethods()
                               .ForEach(methodInfo => {
                                   var methodBuilder = new MethodWeaverBuilder(methodInfo, aspect, factory);
                                   
                                   _builder.Add(methodBuilder);
                               });
                     });
        }

        public ITypeWeaver Build() {
            return _builder.Build();
        }
    }
}
