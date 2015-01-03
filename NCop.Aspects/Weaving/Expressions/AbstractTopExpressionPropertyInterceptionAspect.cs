using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal abstract class AbstractTopExpressionPropertyInterceptionAspect : AbstractAspectPropertyExpression
    {
        protected AbstractTopExpressionPropertyInterceptionAspect(IAspectMethodExpression aspectExpression, IPropertyAspectDefinition aspectDefinition = null)
            : base(aspectExpression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var clonedAspectWeavingSettings = aspectWeavingSettings.CloneToWith<AspectPropertyMethodWeavingSettingsImpl>(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
                settings.PropertyInfoContract = aspectDefinition.PropertyInfoContract;
            });

            var bindingWeaver = new IsolatedPropertyInterceptionBindingWeaver(aspectExpression, aspectDefinition, clonedAspectWeavingSettings);

            return CreateAspect(aspectDefinition, clonedAspectWeavingSettings, bindingWeaver.WeavedType);
        }

        protected abstract IAspectWeaver CreateAspect(IAspectDefinition aspectDefinition, IAspectPropertyMethodWeavingSettings aspectWeavingSettings, FieldInfo weavedType);
    }
}

