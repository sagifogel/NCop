using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class OnMethodExceptionAdviceWeaver : AbstractAdviceWeaver
    {
        public OnMethodExceptionAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings)
            : base(adviceWeavingSettings) {
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            throw new NotImplementedException();
        }
    }
}
