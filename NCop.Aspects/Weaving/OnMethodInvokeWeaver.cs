using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using NCop.Weaving.Extensions;

namespace NCop.Aspects.Weaving
{
    internal class OnMethodInvokeWeaver : AbstractAdviceWeaver
    {
        public OnMethodInvokeWeaver(IAdviceWeavingSettings adviceWeavingSettings)
            : base(adviceWeavingSettings) {
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            var aspectMemeber = aspectRepository.GetAspectFieldByType(aspectType);
            var onInvokeMethod = aspectMemeber.FieldType.GetMethod("OnInvoke");

            ilGenerator.Emit(OpCodes.Ldsfld, aspectMemeber);
            ilGenerator.EmitLoadLocal(argumentsWeaver.Weave(ilGenerator));
            ilGenerator.Emit(OpCodes.Callvirt, onInvokeMethod);

            return ilGenerator;
        }
    }
}
