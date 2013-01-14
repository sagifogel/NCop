using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core.Weaving.Responsibility
{
	public abstract class AbstractMethodWeaverHandler : IMethodWeaverHandler
	{
		protected AbstractMethodWeaverHandler(Type type) {
			Type = type;
			TypeDefinition = TypeDefinition;
		}

		public abstract bool CanHandle { get; }

		protected Type Type { get; private set; }

		protected ITypeDefinition TypeDefinition { get; private set; }

		protected abstract IMethodWeaver HandleInternal(MethodInfo methodInfo, ITypeDefinition typeDefinition);

		public IMethodWeaverHandler NextHandler { get; protected set; }

		public IMethodWeaverHandler SetNextHandler(IMethodWeaverHandler nextHandler) {
			return NextHandler = nextHandler;
		}

		public IMethodWeaver Handle(MethodInfo methodInfo, ITypeDefinition typeDefinition) {
			if (CanHandle) {
				return HandleInternal(methodInfo, typeDefinition);
			}

			return NextHandler.Handle(methodInfo, typeDefinition);
		}
	}
}
