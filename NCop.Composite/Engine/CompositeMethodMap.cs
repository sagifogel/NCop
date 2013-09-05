using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Core;
using NCop.Core.Extensions;

namespace NCop.Composite.Engine
{
	public class CompositeMethodMap : AbstractCompositeMemberMap<MethodInfo>, ICompositeMethodMap
	{
		public CompositeMethodMap(Type contractType, Type implementationType, MethodInfo contractMethod, MethodInfo implementationMethod, MethodInfo compositeMethod)
			: base(contractType, implementationType, contractMethod, implementationMethod, compositeMethod) {
		}
	}
}
