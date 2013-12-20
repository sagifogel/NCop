using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class AspectWeavingSettings : IAspectWeavingSettings
    {
        internal static AspectWeavingSettings Empty = new AspectWeavingSettings();

        internal AspectWeavingSettings(IWeavingSettings weavingSettings, IArgumentsWeaver argumentsWeaver, IAspectRepository aspectRepository = null, IAspectArgsMapper aspectArgsMapper = null) {
            WeavingSettings = weavingSettings;
            ArgumentsWeaver = argumentsWeaver;
            AspectRepository = aspectRepository;
            AspectArgsMapper = aspectArgsMapper;
        }

        private AspectWeavingSettings() {
        }

        public IWeavingSettings WeavingSettings { get; private set; }

        public IArgumentsWeaver ArgumentsWeaver { get; private set; }

        public IAspectRepository AspectRepository { get; private set; }

        public IAspectArgsMapper AspectArgsMapper { get; private set; }
    }
}
