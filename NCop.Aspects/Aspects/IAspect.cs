using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Aspects
{
	public interface IAspect
	{
		Type AspectType { get; }
		int AspectPriority { get; }
	}
}
