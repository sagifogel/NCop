using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class OnMethodInvokeWeaver : AbstractAdviceWeaver
    {
        public OnMethodInvokeWeaver(IMethodLocalWeaver aspectArgsLocalWeaver)
            : base(aspectArgsLocalWeaver) {
        }

        public override ILGenerator Weave(ILGenerator iLGenerator, ITypeDefinition typeDefinition) {
            throw new NotImplementedException();
        }
    }
}
