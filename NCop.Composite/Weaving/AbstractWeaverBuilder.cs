using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Weaving
{
    public abstract class AbstractWeaverBuilder<TMember> where TMember : MemberInfo
    {
        protected Type ContractType = null;
        protected TMember MemberInfo = null;
        protected Type ImplementationType = null;
        protected ITypeDefinitionFactory TypeDefinitionFactory = null;

        public AbstractWeaverBuilder(TMember memberInfo, Type implementationType, Type contractType, ITypeDefinitionFactory typeDefinitionFactory) {
            ContractType = contractType;
            MemberInfo = memberInfo;
            ImplementationType = implementationType;
            TypeDefinitionFactory = typeDefinitionFactory;
        }
    }
}
