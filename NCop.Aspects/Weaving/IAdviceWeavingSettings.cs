using System;

namespace NCop.Aspects.Weaving
{
	public interface IAdviceWeavingSettings : IAspectWeavingSettings
	{
		Type AspectType { get; }
        IArgumentsWeavingSettings ArgumentsWeavingSettings { get; }
    }
}
