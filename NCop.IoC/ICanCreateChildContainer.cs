using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.IoC
{
	public interface ICanCreateChildContainer
	{
		INCopDependencyResolver CreateChildContainer();
	}
}
