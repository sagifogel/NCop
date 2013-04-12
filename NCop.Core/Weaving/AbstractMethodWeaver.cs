using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
    public abstract class AbstractMethodWeaver : IMethodWeaver
    {
        public AbstractMethodWeaver(MethodInfo methodInfo, Type type) {
            Type = type;
            MethodInfo = methodInfo;
        }

        protected Type Type { get; set; }

        protected MethodInfo MethodInfo { get; set; }

        public abstract void WeaveEndMethod(ILGenerator ilGenerator);

        public IMethodEndWeaver MethodEndWeaver { get; protected set; }

        public IMethodScopeWeaver MethodScopeWeaver { get; protected set; }

        public abstract MethodBuilder DefineMethod(ITypeDefinition typeDefinition);

        public IMethodSignatureWeaver MethodDefintionWeaver { get; protected set; }

        public abstract ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition);
    }
}
