using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class AdviceWeavingSettings : AspectWeavingSettings, IAdviceWeavingSettings
    {
        internal AdviceWeavingSettings(Type aspectType, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings, aspectWeavingSettings.ArgumentsWeaver, aspectWeavingSettings.AspectRepository) {
            AspectType = aspectType;
        }

        public Type AspectType { get; private set; }
    }
}
