using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public abstract class AbstractMethodWeaver : IMethodWeaver
    {
        public AbstractMethodWeaver(MethodInfo methodInfo, Type implementationType, Type contractType) {
            MethodInfo = methodInfo;
            ContractType = contractType;
            ImplementationType = implementationType;
        }

        public Type ContractType { get; protected set; }

        public Type ImplementationType { get; protected set; }

        public MethodInfo MethodInfo { get; protected set; }

        public IMethodEndWeaver MethodEndWeaver { get; protected set; }

        public IMethodScopeWeaver MethodScopeWeaver { get; protected set; }

        public IMethodSignatureWeaver MethodDefintionWeaver { get; protected set; }

        public virtual MethodBuilder DefineMethod(ITypeDefinition typeDefinition) {
            return MethodDefintionWeaver.Weave(MethodInfo, typeDefinition);
        }

        public virtual ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition) {
            return MethodScopeWeaver.Weave(ilGenerator, typeDefinition);
        }

        public virtual void WeaveEndMethod(ILGenerator ilGenerator) {
            MethodEndWeaver.Weave(MethodInfo, ilGenerator);
        }
    }
}
