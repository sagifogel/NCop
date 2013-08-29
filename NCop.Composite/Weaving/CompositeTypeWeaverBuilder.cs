using System;
using NCop.Aspects.Aspects;
using NCop.Composite.Engine;
using NCop.Core.Extensions;
using NCop.IoC;
using NCop.Mixins.Engine;
using NCop.Mixins.Weaving;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal class CompositeTypeWeaverBuilder : ITypeWeaverBuilder
    {
        private readonly MixinsTypeWeaverBuilder builder = null;

        internal CompositeTypeWeaverBuilder(Type compositeType, IRegistry registry) {
            var mixinsMap = new MixinsMap(compositeType);
			var methodJoiner = new MethodJoiner(compositeType, mixinsMap) as IMethodJoiner;
			var aspectsMap = new AspectsMap(compositeType, null);
            var factory = new MixinsTypeDefinitionWeaver(compositeType, mixinsMap);
            var propertiesJoiner = new PropertiesJoiner(mixinsMap);

            builder = new MixinsTypeWeaverBuilder(compositeType, factory, registry);

            mixinsMap.ForEach(map => {
                builder.Add(map);
            });

            methodJoiner.ForEach(joinedMethod => {
                var methodBuilder = new MethodWeaverBuilder(joinedMethod.ImplementationMethod, joinedMethod.ImplementationType, joinedMethod.ContractType, factory);

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
