using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class MethodDecoratorWeaver : AbstractMethodWeaver
    {
		public MethodDecoratorWeaver(IMethodWeavingSettings weavingSettings)
			: base(weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
			MethodScopeWeaver = new MethodDecoratorScopeWeaver(weavingSettings);
			MethodDefintionWeaver = new MethodSignatureWeaver(weavingSettings.TypeDefinition);
		}

        public override MethodBuilder DefineMethod() {
            return MethodDefintionWeaver.Weave(MethodInfoImpl);
        }

        public override ILGenerator WeaveMethodScope(ILGenerator ilGenerator) {
            return MethodScopeWeaver.Weave(ilGenerator);
        }

        public override void WeaveEndMethod(ILGenerator ilGenerator) {
            MethodEndWeaver.Weave(MethodInfoImpl, ilGenerator);
        }
    }
}
