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
        protected readonly Type contractType = null;
        protected readonly ITypeDefinition typeDefinition = null;

        protected AbstractWeaverBuilder(Type contractType, ITypeDefinition typeDefinition) {
            this.contractType = contractType;
            this.typeDefinition = typeDefinition;
        }
    }
}
