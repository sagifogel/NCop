using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving
{
	internal class AdviceWeavingSettings : AspectMethodWeavingSettingsImpl, IAdviceWeavingSettings
	{
        internal AdviceWeavingSettings(IAspectMethodWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings) {
			AspectType = argumentsWeavingSettings.AspectType;
            ArgumentsWeavingSettings = argumentsWeavingSettings;
            WeavingSettings = aspectWeavingSettings.WeavingSettings;
			AspectRepository = aspectWeavingSettings.AspectRepository;
			AspectArgsMapper = aspectWeavingSettings.AspectArgsMapper;
            LocalBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
        }

		public Type AspectType { get; private set; }

        public IArgumentsWeavingSettings ArgumentsWeavingSettings { get; set; }
	}
}
