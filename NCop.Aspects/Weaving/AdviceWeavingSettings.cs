using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class AdviceWeavingSettings : AspectWeavingSettings, IAdviceWeavingSettings
    {
        internal AdviceWeavingSettings(Type aspectType, IAspectArgumentWeaver argumentsWeaver, IAspectRepository aspectRepository)
            : base(argumentsWeaver, aspectRepository) {
            AspectType = aspectType;
        }

        public Type AspectType { get; private set; }
    }
}
