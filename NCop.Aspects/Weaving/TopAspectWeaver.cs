using NCop.Aspects.Weaving.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
	class TopAspectWeaver : IAspectWeaver
	{
        private readonly IAspectExpression aspectExpression = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;

        public TopAspectWeaver(IAspectExpression aspectExpression, IAspectWeavingSettings aspectWeavingSettings) {
            this.aspectExpression = aspectExpression;
            this.aspectWeavingSettings = aspectWeavingSettings;
        }

		public ILGenerator Weave(ILGenerator ilGenerator) {
            var reduced = aspectExpression.Reduce(aspectWeavingSettings, true);

            return reduced.Weave(ilGenerator);
		}
	}
}
