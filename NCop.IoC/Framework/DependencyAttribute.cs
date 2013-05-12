using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC.Framework
{
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Property | AttributeTargets.GenericParameter | AttributeTargets.Parameter)]
	public class DependencyAttribute : Attribute
	{
	}
}
