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
            ILGenerator ilGenerator = null;
            MethodBuilder methodBuilder = null;
            var methodParameters = ResolveParameterTypes();
            IAspectArgumentWeaver argumentsWeaver = null;

            methodBuilder = typeBuilder.DefineMethod("Invoke", methodAttr, callingConventions, methodParameters.ReturnType, methodParameters.Parameters);
            ilGenerator = methodBuilder.GetILGenerator();
            argumentsWeaver.Weave(ilGenerator);
            methodScopeWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}
