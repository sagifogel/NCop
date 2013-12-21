using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class AspectDecoratorExpression : IAspectExpression
    {
        private readonly IAspectWeaver weaver = null;

		internal AspectDecoratorExpression(IWeavingSettings weavingSettings) {
			weaver = new AspectDecoratorWeaver(weavingSettings);
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings settings) {
            return weaver;
        }
    }
}
