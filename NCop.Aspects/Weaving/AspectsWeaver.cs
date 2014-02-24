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
        private readonly IAspectExpression aspectExpression = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;

        public AspectsWeaver(IAspectExpression aspectExpression, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings) {
            this.aspectExpression = aspectExpression;
            this.aspectWeavingSettings = aspectWeavingSettings;
		}

		public ILGenerator Weave(ILGenerator ilGenerator) {
            weaver = aspectExpression.Reduce(aspectWeavingSettings);

			return weaver.Weave(ilGenerator);
		}
	}
}
