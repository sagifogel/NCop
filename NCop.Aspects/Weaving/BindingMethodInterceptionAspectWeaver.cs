using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;
using System.Reflection;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Weaving
{
    internal class BindingMethodInterceptionAspectWeaver : AbstractBindingAspectWeaver
    {
        private readonly IAspectExpression aspectExpression = null;

        internal BindingMethodInterceptionAspectWeaver(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition)
            : base(aspectDefinition) {
            this.aspectExpression = aspectExpression;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var reducer = aspectExpression.Reduce(aspectWeavingSettings);

            return new MethodInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, WeavedType);
        }
    }
}
