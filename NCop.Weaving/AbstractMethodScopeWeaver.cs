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
        protected readonly MethodInfo MethodInfo = null;
        protected readonly Type ImplementationType = null;

		public AbstractMethodScopeWeaver(MethodInfo methodInfo, Type implementationType, Type contractType) {
            MethodInfo = methodInfo;
            ContractType = contractType;
            ImplementationType = implementationType;
        }

        public abstract ILGenerator Weave(ILGenerator iLGenerator, ITypeDefinition typeDefinition);
	}
}
