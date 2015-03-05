using System.Collections.Generic;
using System.Reflection;

namespace NCop.Core.Runtime
{
	public interface IRuntimeSettings
	{
		IEnumerable<Assembly> Assemblies { get; }
	}
}
