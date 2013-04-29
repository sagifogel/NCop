using NCop.Aspects.Aspects;
using NCop.Weaving;
using System;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public class FirstOnMethodBoundryAspectStrategy : AbstractFirstAspectStrategy
    {
        public FirstOnMethodBoundryAspectStrategy(IAspectDefinitionCollection aspectsDefinition)
            : base(aspectsDefinition) {
        }

        public override IMethodEndWeaver MethodEndWeaver {
            get {
                return null;
            }
        }

        public override IMethodScopeWeaver MethodScopeWeaver {
            get {
                return null;
            }
        }

        public override IMethodSignatureWeaver MethodDefintionWeaver {
            get {
                return null;
            }
        }

        public override void WeaveEndMethod(ILGenerator ilGenerator) {
        }

        public override MethodBuilder DefineMethod(ITypeDefinition typeDefinition) {
            return null;
        }
        
        public override ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition) {
            return null;
        }
    }
}
