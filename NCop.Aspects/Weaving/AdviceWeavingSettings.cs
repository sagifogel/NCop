using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving
{
	internal class AdviceWeavingSettings : AspectWeavingSettings, IAdviceWeavingSettings
	{
        internal AdviceWeavingSettings(Type aspectType, IAspectWeavingSettings aspectWeavingSettings, ILocalBuilderRepository localBuilderRepository, IArgumentsWeavingSettings argumentsWeavingSettings) {
			AspectType = aspectType;
            LocalBuilderRepository = localBuilderRepository;
            ArgumentsWeavingSettings = argumentsWeavingSettings;
            WeavingSettings = aspectWeavingSettings.WeavingSettings;
			AspectRepository = aspectWeavingSettings.AspectRepository;
			AspectArgsMapper = aspectWeavingSettings.AspectArgsMapper;
		}

		public Type AspectType { get; private set; }

        public IArgumentsWeavingSettings ArgumentsWeavingSettings { get; set; }
	}
}
