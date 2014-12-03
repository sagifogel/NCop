using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopExpressionGetPropertyInterceptionAspect : AbstractAspectPropertyExpression
    {
        internal TopExpressionGetPropertyInterceptionAspect(IAspectMethodExpression aspectExpression, IPropertyAspectDefinition aspectDefinition = null)
            : base(aspectExpression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectMethodWeavingSettings aspectWeavingSettings) {
            var clonedAspectWeavingSettings = aspectWeavingSettings.CloneToWith<AspectPropertyMethodWeavingSettingsImpl>(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
                settings.PropertyInfoContract = aspectDefinition.PropertyInfoContract;
            });

            var bindingWeaver = new IsolatedPropertyInterceptionBindingWeaver(aspectExpression, aspectDefinition, clonedAspectWeavingSettings);

            return new TopGetPropertyInterceptionAspectWeaver(aspectDefinition, clonedAspectWeavingSettings, bindingWeaver.WeavedType);
        }
    }
}
