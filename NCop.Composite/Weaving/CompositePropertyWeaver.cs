using System;
using System.Reflection;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using NCop.Weaving;
using NCop.Aspects.Extensions;

namespace NCop.Composite.Weaving
{
    public class CompositePropertyWeaver : AbstractPropertyWeaver
    {
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;
        private readonly IAspectDefinitionCollection aspectDefinitions = null;

        public CompositePropertyWeaver(PropertyInfo propertyInfo, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(propertyInfo, aspectWeavingSettings.WeavingSettings) {
            this.propertyInfo = propertyInfo;
            this.aspectDefinitions = aspectDefinitions;
            this.aspectWeavingSettings = aspectWeavingSettings;
        }

        public override IMethodWeaver GetGetMethod() {
            if (CanRead) {
                return new GetPropertyAspectWeaver(aspectDefinitions, aspectWeavingSettings.ToGetPropertyAspectWeavingSettings(propertyInfo));
            }

            return null;
        }

        public override IMethodWeaver GetSetMethod() {
            if (CanWrite) {
                return new SetPropertyAspectWeaver(aspectDefinitions, aspectWeavingSettings.ToSetPropertyAspectWeavingSettings(propertyInfo));
            }

            return null;
        }
    }
}
