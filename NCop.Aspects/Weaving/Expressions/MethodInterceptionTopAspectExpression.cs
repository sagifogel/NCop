using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class MethodInterceptionTopAspectExpression : AbstractAspectExpression
    {
        internal MethodInterceptionTopAspectExpression(IAspectExpression expression, IAspectDefinition aspectDefinition = null)
            : base(expression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            ITypeReflector typeReflector = new AspectWeaverWithBinding(expression, aspectDefinition, aspectWeavingSettings);

            var clonedSettings = aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });

            return new MethodInterceptionTopAspectWeaver(aspectDefinition, clonedSettings, typeReflector.WeavedType);
        }
    }
}
