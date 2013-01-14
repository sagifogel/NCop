using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCop.Core;
using NCop.Core.Mixin;
using NCop.Core.Weaving;
using NCop.Core.Extensions;
using NCop.Core.Weaving.Proxies;
using System;

namespace NCop.Mixins.Weaving
{
	public class MixinsWeaverStrategy : ITypeWeaver
	{
		private readonly Type _mixinsType = null;
		private readonly Tuples<MixinMap, MixinWeaverStrategy> _mixinsTuples = null;

		public MixinsWeaverStrategy(Type mixinsType, Tuples<MixinMap, MixinWeaverStrategy> mixinsTuples) {
			_mixinsType = mixinsType;
			_mixinsTuples = mixinsTuples;
		}

		public void Weave() {
			var maps = _mixinsTuples.Select(tuple => tuple.Item1);
			var typeBuilder = NCopTypeBuilder.DefineType(_mixinsType, TypeAttributes.Class, new[] { _mixinsType });
			var mixinsTypeDefinitionWeaver = new MixinsTypeDefinitionWeaver(typeBuilder, maps);
			var typeDefinition = mixinsTypeDefinitionWeaver.Weave();

			_mixinsTuples.ForEach(tuple => {
				var weavers = tuple.Item2.MethodWeavers;

				weavers.ForEach(methodWeaver => {
					var methodBuilder = methodWeaver.DefineMethod();
					var ilGenerator = methodBuilder.GetILGenerator();

					methodWeaver.WeaveMethodScope(ilGenerator, typeDefinition);
					methodWeaver.WeaveEndMethod(ilGenerator);
				});
			});
		}
	}
}
