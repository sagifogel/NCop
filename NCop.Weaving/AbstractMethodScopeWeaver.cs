using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
	public abstract class AbstractMethodScopeWeaver : IMethodScopeWeaver
	{
		protected readonly Type ContractType = null;
        protected readonly Type ImplementationType = null;
        protected readonly MethodInfo MethodInfoImpl = null;

		public AbstractMethodScopeWeaver(MethodInfo methodInfoImpl, Type implementationType, Type contractType) {
            ContractType = contractType;
            MethodInfoImpl = methodInfoImpl;
            ImplementationType = implementationType;
        }

        public abstract ILGenerator Weave(ILGenerator iLGenerator, ITypeDefinition typeDefinition);
	}
}
