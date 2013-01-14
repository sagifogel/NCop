using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving.Responsibility
{
	public sealed class NullObjectMethdodWeaverHanler : IMethodWeaverHandler
	{
		public IMethodWeaverHandler SetNextHandler(IMethodWeaverHandler nextHanlder) {
			throw new InvalidOperationException("It is impossible to set another handler after NullObjectHanler.");
		}

		public IMethodWeaver Handle(MethodInfo methodInfo, ITypeDefinition typeDefinition) {
			return null;
		}
	}
}
