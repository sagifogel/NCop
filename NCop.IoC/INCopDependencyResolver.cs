using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
	public interface INCopDependencyResolver : IDisposable
	{
		void Configure();
		TService Resolve<TService>();
		TService TryResolve<TService>();
		TService ResolveNamed<TService>(string name);
		TService TryResolveNamed<TService>(string name);
	}
}

