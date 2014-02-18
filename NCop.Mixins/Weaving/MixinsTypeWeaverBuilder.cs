using NCop.Core;
using NCop.Weaving;
using NCop.Mixins.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.IoC;

namespace NCop.Mixins.Weaving
{
	public class MixinsTypeWeaverBuilder : AbstractTypeWeaverBuilder, IMixinMapBag
	{
		protected readonly INCopRegistry registry = null;
		protected readonly List<TypeMap> mixinsMap = null;

		public MixinsTypeWeaverBuilder(Type type, ITypeDefinition typeDefinition, INCopRegistry registry)
			: base(type, typeDefinition) {
			this.registry = registry;
			mixinsMap = new List<TypeMap>();
		}

		public void Add(TypeMap item) {
			mixinsMap.Add(item);
		}

		public override void AddMethodWeavers() {
			base.AddMethodWeavers();

			mixinsMap.ForEach(map => {
				registry.Register(map.ImplementationType, map.ContractType);
			});
		}

		public override ITypeWeaver CreateTypeWeaver() {
			return new MixinsWeaverStrategy(typeDefinition, methodWeavers, registry);
		}
	}
}
