using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Responsibility;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.Core.Mixin;
using NCop.Weaving;
using NCop.Mixins.Engine;
using NCop.Mixins.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Composite.Weaving
{
    internal class CompositeTypeWeaverBuilder : ITypeWeaverBuilder
    {
        private readonly MixinsTypeWeaverBuilder builder = null;

        internal CompositeTypeWeaverBuilder(Type type) {
            var mixinsMap = new MixinsMap(type);
            var aspectMap = new AspectsMap(type);
            var factory = new MixinsTypeDefinitionWeaver(type, mixinsMap);
            var metohdJoiner = new MethodJoiner(aspectMap, mixinsMap);

            builder = new MixinsTypeWeaverBuilder(type, factory);

            mixinsMap.ForEach(map => {
                builder.Add(map);
            });

            metohdJoiner.ForEach(tuple => {
                var methodBuilder = new MethodWeaverBuilder(tuple.Item1, tuple.Item2, factory);

                builder.Add(methodBuilder);
            });
        }

        public ITypeWeaver Build() {
            return builder.Build();
        }
    }
}
