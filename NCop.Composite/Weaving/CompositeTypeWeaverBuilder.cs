using System;
using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Composite.Engine;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.IoC;
using System.Linq;
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
            var aspectMappedMembers = new AspectMemberMapper(compositeType, mixinsMap);
            var aspectsMap = new AspectsMap(compositeType, aspectMappedMembers);
            var typeDefinitionWeaver = new MixinsTypeDefinitionWeaver(compositeType, mixinsMap);
            var compositeMappedMembers = new CompositeMemberMapper(aspectsMap, aspectMappedMembers);
			var typeDefinition = typeDefinitionWeaver.Weave();

			builder = new MixinsTypeWeaverBuilder(compositeType, typeDefinition, registry);

            mixinsMap.ForEach(map => {
                builder.Add(map);
            });

            compositeMappedMembers.Methods.ForEach(compositeMethodMap => {
				var methodBuilder = new CompositeMethodWeaverBuilder(compositeMethodMap, typeDefinition);

                builder.Add(methodBuilder);
            });

            compositeMappedMembers.Properties.ForEach(compositePropertyMap => {
				var propertyBuilder = new CompositePropertyWeaverBuilder(compositePropertyMap, typeDefinition);

                builder.Add(propertyBuilder);
            });
        }

        public ITypeWeaver Build() {
            return builder.Build();
        }
    }
}
