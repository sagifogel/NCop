using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving
{
	public interface IAdviceWeavingSettings : IAspectWeavingSettings
	{
		Type AspectType { get; }
		ILocalBuilderRepository LocalBuilderRepository { get; }
	}
}
