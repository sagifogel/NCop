using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class TopMethodInterceptionAspectExpression : AbstractAspectMethodExpression
    {
        internal TopMethodInterceptionAspectExpression(IAspectMethodExpression aspectExpression, IAspectDefinition aspectDefinition)
            : base(aspectExpression, aspectDefinition) {
        }

		public override IAspectWeaver Reduce(IAspectMethodWeavingSettings aspectWeavingSettings) {
            var clonedAspectWeavingSettings = aspectWeavingSettings.CloneWith(settings => {
                var localBuilderRepository = new LocalBuilderRepository();
                var methodImpl = aspectWeavingSettings.WeavingSettings.MethodInfoImpl;
                var aspectArgumentImplType = aspectDefinition.ToAspectArgumentImpl();

                settings.LocalBuilderRepository = localBuilderRepository;
                settings.ByRefArgumentsStoreWeaver = new TopAspectByRefArgumentsStoreWeaver(aspectArgumentImplType, methodImpl, localBuilderRepository);
            });

            var bindingWeaver = new IsolatedMethodInterceptionBindingWeaver(aspectExpression, aspectDefinition, clonedAspectWeavingSettings);

            return new TopMethodInterceptionAspectWeaver(aspectDefinition, clonedAspectWeavingSettings, bindingWeaver.WeavedType);
        }
    }
}
