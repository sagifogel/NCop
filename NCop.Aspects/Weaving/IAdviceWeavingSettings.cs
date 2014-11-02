using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving
{
	public interface IAdviceWeavingSettings : IAspectMethodWeavingSettings
	{
		Type AspectType { get; }
        IArgumentsWeavingSettings ArgumentsWeavingSettings { get; }
    }
}
