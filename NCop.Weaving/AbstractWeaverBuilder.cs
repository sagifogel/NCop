using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Weaving
{
    public abstract class AbstractWeaverBuilder<TMember> where TMember : MemberInfo
    {
        protected readonly Type ContractType = null;
        protected readonly TMember MemberInfoImpl = null;
        protected readonly Type ImplementationType = null;
        protected readonly ITypeDefinition TypeDefinition = null;

        public AbstractWeaverBuilder(TMember memberInfoImpl, Type implementationType, Type contractType, ITypeDefinition typeDefinition) {
            ContractType = contractType;
            MemberInfoImpl = memberInfoImpl;
            ImplementationType = implementationType;
            TypeDefinition = typeDefinition;
        }
    }
}
