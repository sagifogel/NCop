using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractPropertyInterceptionBindingWeaver : AbstractBindingPropertyAspectWeaver
    {
        protected readonly Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;
        protected readonly IAspectMethodExpression aspectExpression = null;
        protected IAspectMethodWeavingSettings aspectWeavingSettings = null;

        internal AbstractPropertyInterceptionBindingWeaver(IAspectMethodExpression aspectExpression, IPropertyAspectDefinition aspectDefinition, IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(aspectDefinition) {
            this.aspectExpression = aspectExpression;
            this.aspectWeavingSettings = aspectWeavingSettings;
            lazyWeavedType = new Core.Lib.Lazy<FieldInfo>(WeaveType);
        }

        public override FieldInfo WeavedType {
            get {
                return lazyWeavedType.Value;
            }
        }

        protected virtual FieldInfo WeaveType() {
            IAspectWeaver aspectWeaver = null;
            IMethodBindingWeaver bindingWeaver = null;
            var aspectType = aspectDefinition.Aspect.AspectType;
            var aspectSettings = GetAspectsWeavingSettings() as IAspectPropertyMethodWeavingSettings;

            aspectWeaver = aspectExpression.Reduce(aspectSettings);
            bindingSettings.LocalBuilderRepository = aspectSettings.LocalBuilderRepository;
            bindingWeaver = new PropertyInterceptionBindingWeaver(aspectType, bindingSettings, aspectSettings, aspectWeaver);

            return bindingWeaver.Weave();
        }

        protected abstract IAspectMethodWeavingSettings GetAspectsWeavingSettings();
    }
}
