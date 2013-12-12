using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Composite.Weaving;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using NCop.Aspects.Framework;
using NCop.Aspects.Engine;
using NCop.Core.Extensions;
using System.Threading;
using NCop.Weaving.Extensions;

namespace NCop.Aspects.Weaving
{
    internal class OnMethodInterceptionBindingWeaver : AbstractMethodBindingWeaver
    {
        internal OnMethodInterceptionBindingWeaver(BindingSettings bindingSettings, IAspcetWeaver methodScopeWeaver)
            : base(bindingSettings, methodScopeWeaver) {
        }

        protected override void WeaveInvokeMethod() {
            ILGenerator ilGenerator = null;
            LocalBuilder argsBuilder = null;
            MethodBuilder methodBuilder = null;
            var methodParameters = ResolveParameterTypes();

            methodParameters.Parameters[0] = methodParameters.Parameters[0].MakeByRefType();
            methodBuilder = typeBuilder.DefineMethod("Invoke", methodAttr, callingConventions, methodParameters.ReturnType, methodParameters.Parameters);
            ilGenerator = methodBuilder.GetILGenerator();
            argsBuilder = bindingSettings.ArgumentsWeaver.Weave(ilGenerator);
            methodScopeWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}
