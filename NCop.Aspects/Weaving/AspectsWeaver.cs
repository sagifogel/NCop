using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
	internal class AspectsWeaver : IAspectWeaver
	{
		private IAspectWeaver weaver = null;
		private readonly IAspectExpression expression = null;
		private readonly IAspectWeavingSettings settings = null;
		private readonly AspectsAttributeWeaver aspectAttributeWeaver = null;
		private readonly AspectArgsMapperWeaver aspectArgsMapperWeaver = null;

		public AspectsWeaver(IAspectExpression expression, IAspectDefinitionCollection aspectDefinitions, IWeavingSettings weavingSettings) {
			this.expression = expression;
			aspectArgsMapperWeaver = new AspectArgsMapperWeaver();
			aspectAttributeWeaver = new AspectsAttributeWeaver(aspectDefinitions);

			settings = new AspectWeavingSettings {
                WeavingSettings = weavingSettings,
				AspectRepository = aspectAttributeWeaver,
				AspectArgsMapper = aspectArgsMapperWeaver				
			};
		}

		public ILGenerator Weave(ILGenerator ilGenerator) {
			aspectAttributeWeaver.Weave();
			aspectArgsMapperWeaver.Weave();
			weaver = expression.Reduce(settings);

			return weaver.Weave(ilGenerator);
		}
	}
}
