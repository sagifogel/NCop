using NCop.Aspects.Aspects;
using NCop.Core.Weaving;
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

        public override MethodBuilder DefineMethod() {
            return null;
        }

        public override void WeaveEndMethod(ILGenerator ilGenerator) {
        }

        public override ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition) {
            return null;
        }
    }
}
