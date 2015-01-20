using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractPropertyInterceptionBindingWeaver : AbstractBindingPropertyAspectWeaver
    {
        protected IAspectWeavingSettings aspectWeavingSettings = null;
        protected readonly Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;

        internal AbstractPropertyInterceptionBindingWeaver(IPropertyAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectDefinition) {
            this.aspectWeavingSettings = aspectWeavingSettings;
            lazyWeavedType = new Core.Lib.Lazy<FieldInfo>(WeaveType);
        }

        public override FieldInfo WeavedType {
            get {
                return lazyWeavedType.Value;
            }
        }

        protected abstract FieldInfo WeaveType();

        protected abstract IAspectWeavingSettings GetAspectsWeavingSettings();
    }
}
