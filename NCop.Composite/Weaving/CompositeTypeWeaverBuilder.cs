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
using NCop.IoC;
using NCop.Composite.Extensions;

namespace NCop.Composite.Weaving
{
    internal class CompositeTypeWeaverBuilder : ITypeWeaverBuilder
    {
        private readonly MixinsTypeWeaverBuilder builder = null;

        internal CompositeTypeWeaverBuilder(Type compositeType, IRegistry registry) {
            var mixinsMap = new MixinsMap(compositeType);
            var aspectMap = new AspectsMap(compositeType);
            var factory = new MixinsTypeDefinitionWeaver(compositeType, mixinsMap);
            var methodJoiner = new MethodJoiner(mixinsMap);
            var propertiesJoiner = new PropertiesJoiner(mixinsMap);

            builder = new MixinsTypeWeaverBuilder(compositeType, factory, registry);

            mixinsMap.ForEach(map => {
                builder.Add(map);
            });

            methodJoiner.ForEach(tuple => {
                var methodBuilder = new MethodWeaverBuilder(tuple.Item1, tuple.Item2, tuple.Item3, factory);

                builder.Add(methodBuilder);
            });

            propertiesJoiner.ForEach(tuple => {
                var propertyBuilder = new PropertyWeaverBuilder(tuple.Item1, tuple.Item2, tuple.Item3, factory);

                builder.Add(propertyBuilder);
            });
        }

        public ITypeWeaver Build() {
            return builder.Build();
        }
    }
}
