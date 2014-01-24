using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class SetReturnValueWeaver : IMethodScopeWeaver
    {
        private readonly Type aspectArgType = null;
        
        internal SetReturnValueWeaver(Type aspectArgType) {
            this.aspectArgType = aspectArgType;
        }

        public ILGenerator Weave(ILGenerator ilGenerator) {
            var setReturnValueMethodInfo = aspectArgType.GetProperty("ReturnValue").GetSetMethod();

            ilGenerator.Emit(OpCodes.Callvirt, setReturnValueMethodInfo);

            return ilGenerator;
        }
    }
}
