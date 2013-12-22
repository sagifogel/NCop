using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving
{
	internal class AdviceWeavingSettings : AspectWeavingSettings, IAdviceWeavingSettings
	{
		internal AdviceWeavingSettings(Type aspectType, IAspectWeavingSettings aspectWeavingSettings, ILocalBuilderRepository localBuilderRepository) {
			AspectType = aspectType;
			WeavingSettings = aspectWeavingSettings.WeavingSettings;
			AspectRepository = aspectWeavingSettings.AspectRepository;
			AspectArgsMapper = aspectWeavingSettings.AspectArgsMapper;
			LocalBuilderRepository = localBuilderRepository;
		}

		public Type AspectType { get; private set; }
		public ILocalBuilderRepository LocalBuilderRepository { get; private set; }
	}
}
