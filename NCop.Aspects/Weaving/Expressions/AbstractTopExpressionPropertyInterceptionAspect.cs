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
        protected AbstractTopExpressionPropertyInterceptionAspect(IAspectExpression aspectExpression, IPropertyAspectDefinition aspectDefinition = null)
            : base(aspectExpression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var clonedAspectWeavingSettings = aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });

            var bindingWeaver = new IsolatedPropertyInterceptionBindingWeaver(aspectExpression, aspectDefinition, clonedAspectWeavingSettings);

            return CreateAspect(aspectDefinition, clonedAspectWeavingSettings, bindingWeaver.WeavedType);
        }

        protected abstract IAspectWeaver CreateAspect(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType);
    }
}

