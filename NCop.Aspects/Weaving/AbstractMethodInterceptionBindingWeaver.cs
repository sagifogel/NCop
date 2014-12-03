using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractMethodInterceptionBindingWeaver : AbstractBindingMethodAspectWeaver
    {
        protected readonly Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;
        protected readonly IAspectMethodExpression aspectExpression = null;
        protected IAspectMethodWeavingSettings aspectWeavingSettings = null;

        internal AbstractMethodInterceptionBindingWeaver(IAspectMethodExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectMethodWeavingSettings aspectWeavingSettings)
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
            var aspectSetings = GetAspectsWeavingSettings();

            aspectWeaver = aspectExpression.Reduce(aspectSetings);
            bindingSettings.LocalBuilderRepository = aspectSetings.LocalBuilderRepository;
			bindingWeaver = new MethodInterceptionBindingWeaver(aspectType, bindingSettings, aspectWeavingSettings, aspectWeaver);
            
            return bindingWeaver.Weave();
        }

        protected abstract IAspectMethodWeavingSettings GetAspectsWeavingSettings();
    }
}
