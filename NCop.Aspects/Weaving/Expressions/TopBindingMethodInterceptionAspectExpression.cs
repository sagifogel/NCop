using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;
using System.Reflection;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class TopBindingMethodInterceptionAspectExpression : AbstractAspectMethodExpression
    {
        internal TopBindingMethodInterceptionAspectExpression(IAspectExpression aspectExpression, IMethodAspectDefinition aspectDefinition)
            : base(aspectExpression, aspectDefinition) {
        }

		public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var bindingWeaver = new IsolatedMethodInterceptionBindingWeaver(aspectExpression, aspectDefinition, aspectWeavingSettings);

            return new TopBindingMethodInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, bindingWeaver.WeavedType);
        }
    }
}
