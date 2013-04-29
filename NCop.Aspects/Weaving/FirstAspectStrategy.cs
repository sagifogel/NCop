using NCop.Aspects.Aspects;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public abstract class AbstractFirstAspectStrategy : IMethodWeaver
    {
        public AbstractFirstAspectStrategy(IAspectDefinitionCollection aspectsDefinition) {
            AspectsDefinition = aspectsDefinition;
        }

        public abstract IMethodEndWeaver MethodEndWeaver { get; }

        public abstract void WeaveEndMethod(ILGenerator ilGenerator);

        public abstract IMethodScopeWeaver MethodScopeWeaver { get; }

        public abstract IMethodSignatureWeaver MethodDefintionWeaver { get; }

        public abstract MethodBuilder DefineMethod(ITypeDefinition typeDefinition); 
        
        protected IAspectDefinitionCollection AspectsDefinition { get; private set; }

        public abstract ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition);
    }
}
