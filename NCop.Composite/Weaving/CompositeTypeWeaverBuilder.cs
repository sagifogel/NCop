using System;
using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Composite.Engine;
using NCop.Core;
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
			var mappedMembers = new CompositeMemberMapper(compositeType, mixinsMap);
			var aspectsMap = new AspectsMap(compositeType, mappedMembers);
			var factory = new MixinsTypeDefinitionWeaver(compositeType, mixinsMap);

			builder = new MixinsTypeWeaverBuilder(compositeType, factory, registry);

			mixinsMap.ForEach(map => {
				builder.Add(map);
			});

			mappedMembers.Methods.ForEach(mappedMethod => {
				var methodBuilder = new MethodWeaverBuilder(mappedMethod.ImplementationMember, mappedMethod.ImplementationType, mappedMethod.ContractType, factory);

				builder.Add(methodBuilder);
			});

			mappedMembers.Properties.ForEach(mappedParoperty => {
				var propertyBuilder = new PropertyWeaverBuilder(mappedParoperty.ImplementationMember, mappedParoperty.ImplementationType, mappedParoperty.ContractType, factory);

				builder.Add(propertyBuilder);
			});
		}

		public ITypeWeaver Build() {
			return builder.Build();
		}
	}
}
