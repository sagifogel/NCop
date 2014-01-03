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
            LocalBuilder argsLocalBuilder = null;
            var aspectMember = aspectRepository.GetAspectFieldByType(aspectType);
            var onInvokeMethod = aspectMember.FieldType.GetMethod("OnInvoke");

            argsLocalBuilder = localBuilderRepository.Get(argumentsWeavingSettings.ArgumentType);
            ilGenerator.Emit(OpCodes.Ldsfld, aspectMember);
            ilGenerator.EmitLoadLocal(argsLocalBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, onInvokeMethod);

            return ilGenerator;
        }

        protected override string AdviceName {
            get {
                return "OnInvoke";
            }
        }
    }
}
