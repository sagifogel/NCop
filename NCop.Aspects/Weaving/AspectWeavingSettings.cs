using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class AspectWeavingSettings : IAspectWeavingSettings
    {
        internal static AspectWeavingSettings Empty = new AspectWeavingSettings();

        internal AspectWeavingSettings(IAspectArgumentWeaver argumentsWeaver, IAspectRepository aspectRepository) {
            ArgumentsWeaver = argumentsWeaver;
            AspectRepository = aspectRepository;
        }

        private AspectWeavingSettings() {
        }

        public IAspectRepository AspectRepository { get; private set; }
        public IAspectArgumentWeaver ArgumentsWeaver { get; private set; }
    }
}
