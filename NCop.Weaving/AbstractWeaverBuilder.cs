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
        protected Type ContractType = null;
        protected TMember MemberInfoImpl = null;
        protected Type ImplementationType = null;
        protected ITypeDefinitionFactory TypeDefinitionFactory = null;

        public AbstractWeaverBuilder(TMember memberInfoImpl, Type implementationType, Type contractType, ITypeDefinitionFactory typeDefinitionFactory) {
            ContractType = contractType;
            MemberInfoImpl = memberInfoImpl;
            ImplementationType = implementationType;
            TypeDefinitionFactory = typeDefinitionFactory;
        }
    }
}
