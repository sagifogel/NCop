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
            var metohdJoiner = new MethodJoiner(aspectMap, mixinsMap);

            _builder = new MixinsTypeWeaverBuilder(type, factory);

            mixinsMap.ForEach(map => {
                _builder.Add(map);
            });

            metohdJoiner.ForEach(tuple => {
                var methodBuilder = new MethodWeaverBuilder(tuple.Item1, tuple.Item2, factory);

                _builder.Add(methodBuilder);
            });
        }

        public ITypeWeaver Build() {
            return _builder.Build();
        }
    }
}
