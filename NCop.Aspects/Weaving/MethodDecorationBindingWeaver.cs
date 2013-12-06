using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class MethodDecoratorBindingWeaver : AbstractMethodBindingWeaver
    {
        internal MethodDecoratorBindingWeaver(BindingSettings bindingSettings, IMethodScopeWeaver methodScopeWeaver)
            : base(bindingSettings, methodScopeWeaver) {
        }

        protected override void WeaveInvokeMethod() {
            var ilGenerator = methodScopeWeaver.Weave(WeaveLoadArgs());

            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}
