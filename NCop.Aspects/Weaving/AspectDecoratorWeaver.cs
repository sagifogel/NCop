using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class AspectDecoratorWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        internal AspectDecoratorWeaver(IWeavingSettings weavingSettings)
            : base(weavingSettings) {
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfoImpl);

            return ilGenerator;
        }
    }
}
