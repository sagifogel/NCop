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
        internal OnMethodInterceptionBindingWeaver(BindingSettings settings, IAspectWeaver methodScopeWeaver, IMethodBindingWeaver nestedMethodBindingWeaver)
            : base(settings, methodScopeWeaver) {
            var argsWeaver = settings.ArgumentsWeaver;
            var localBuilderRepository = new LocalBuilderRepository();
            var interceptionArgsWeaver = new AspectArgumentsWeaver(argsWeaver.ArgumentType, argsWeaver.Parameters, settings.WeavingSettings, localBuilderRepository, nestedMethodBindingWeaver);

            bindingSettings = new BindingSettings {
                ArgumentsWeaver = interceptionArgsWeaver,
                AspectArgsMapper = settings.AspectArgsMapper,
                BindingType = settings.BindingType,
                WeavingSettings = settings.WeavingSettings
            };
        }

        protected override void WeaveInvokeMethod() {
            ILGenerator ilGenerator = null;
            MethodBuilder methodBuilder = null;
            var methodParameters = ResolveParameterTypes();

            methodBuilder = typeBuilder.DefineMethod("Invoke", methodAttr, callingConventions, methodParameters.ReturnType, methodParameters.Parameters);
            ilGenerator = methodBuilder.GetILGenerator();
            bindingSettings.ArgumentsWeaver.Weave(ilGenerator);
            methodScopeWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}
