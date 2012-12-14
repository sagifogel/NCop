using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Core
{
	public abstract class AbstractRuntime : IRuntime
	{
		public abstract void Run();
	}
}
