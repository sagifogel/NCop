using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace NCop.Core.Runtime
{
	public interface IRuntimeSettings
	{
		IEnumerable<Assembly> Assemblies { get; }
	}
}
