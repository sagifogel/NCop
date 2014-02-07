using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodDecoratorAspectWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        private readonly Type previousAspectArgType = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal NestedMethodDecoratorAspectWeaver(Type previousAspectArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            this.previousAspectArgType = previousAspectArgType;
            this.aspectWeavingSettings = aspectWeavingSettings;
            this.argumentsWeavingSettings = argumentsWeavingSettings;
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            var hasByRefParameters = MethodInfoImpl.GetParameters()
                                                   .Any(param => param.ParameterType.IsByRef);

            if (hasByRefParameters) {
                WeaveWithRefParameters(ilGenerator);
            }
            else {
                WeaveRegular(ilGenerator);
            }

            if (argumentsWeavingSettings.IsFunction) {
                var setReturnValueWeaver = new SetReturnValueWeaver(previousAspectArgType);

                setReturnValueWeaver.Weave(ilGenerator);
            }

            return ilGenerator;
        }

        private ILGenerator WeaveWithRefParameters(ILGenerator ilGenerator) {
            var argumentsWeaver = new NestedByRefParamsMethodDecoratorWeaver(previousAspectArgType, aspectWeavingSettings, argumentsWeavingSettings);
            
            argumentsWeaver.Weave(ilGenerator);
            
            return ilGenerator;
        }

        private ILGenerator WeaveRegular(ILGenerator ilGenerator) {
            var argumentsWeaver = new NestedMethodDecoratorArgumentsWeaver(previousAspectArgType, aspectWeavingSettings, argumentsWeavingSettings);

            ilGenerator.Emit(OpCodes.Callvirt, MethodInfoImpl);

            return ilGenerator;
        }
    }
}
