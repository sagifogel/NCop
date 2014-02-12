using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractMethodInterceptionBindingWeaver : AbstractBindingAspectWeaver
    {
        protected readonly IAspectExpression aspectExpression = null;
        protected IAspectWeavingSettings aspectWeavingSettings = null;
        protected readonly NCop.Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;

        internal AbstractMethodInterceptionBindingWeaver(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
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
			bindingWeaver = new OnMethodInterceptionBindingWeaver(aspectType, bindingSettings, aspectWeavingSettings, aspectWeaver);
            
            return bindingWeaver.Weave();
        }

        protected abstract IAspectWeavingSettings GetAspectsWeavingSettings();
    }
}
