using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopMethodInterceptionAspectExpression : AbstractAspectExpression
    {
        internal TopMethodInterceptionAspectExpression(IAspectExpression expression, IAspectDefinition aspectDefinition)
            : base(expression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var aspectWeaver = new TopMethodInterceptionAspectWeaverWithBinding(expression, aspectDefinition, aspectWeavingSettings);
            var typeReflector = aspectWeaver as IBindingTypeReflector;

            var clonedSettings = aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });

            return aspectWeaver.Reduce(clonedSettings);
        }
    }
}
