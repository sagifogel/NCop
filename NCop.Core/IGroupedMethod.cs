using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core
{
	public interface IGroupedMethods : IReadOnlyCollection<MethodInfo>
	{
		MethodInfo GroupedByMethod { get; }
	}
}
