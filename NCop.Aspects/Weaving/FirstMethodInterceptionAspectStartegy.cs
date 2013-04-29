using NCop.Aspects.Aspects;
using NCop.Weaving;
using System;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public class FirstMethodInterceptionAspectStartegy : AbstractFirstAspectStrategy
    {   
        public FirstMethodInterceptionAspectStartegy(IAspectDefinitionCollection aspectsDefinition)
            : base(aspectsDefinition) {
        }
        
        public override IMethodEndWeaver MethodEndWeaver {
            get { throw new NotImplementedException(); }
        }

        public override void WeaveEndMethod(ILGenerator ilGenerator) {
            throw new NotImplementedException();
        }

        public override IMethodScopeWeaver MethodScopeWeaver {
            get { throw new NotImplementedException(); }
        }

        public override IMethodSignatureWeaver MethodDefintionWeaver {
            get { throw new NotImplementedException(); }
        }

        public override MethodBuilder DefineMethod(ITypeDefinition typeDefinition) {
            throw new NotImplementedException();
        }
        
        public override ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition) {
            throw new NotImplementedException();
        }
    }
}
