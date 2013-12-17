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
		private readonly MethodParameters methodParameters = null;

		internal MethodDecoratorBindingWeaver(BindingSettings settings, IMethodScopeWeaver methodScopeWeaver)
			: base(settings, methodScopeWeaver) {
			methodParameters = ResolveParameterTypes();

			bindingSettings = new BindingSettings {
				BindingType = settings.BindingType,
				WeavingSettings = settings.WeavingSettings,
				ArgumentsWeaver = new MethodDecoratorArgumentsWeaver(settings.ArgumentsWeaver.ArgumentType, methodParameters.Parameters, settings.WeavingSettings)
			};
		}

		protected override void WeaveInvokeMethod() {
			ILGenerator ilGenerator = null;
			MethodBuilder methodBuilder = null;

			methodBuilder = typeBuilder.DefineMethod("Invoke", methodAttr, callingConventions, methodParameters.ReturnType, methodParameters.Parameters);
			ilGenerator = methodBuilder.GetILGenerator();
			bindingSettings.ArgumentsWeaver.Weave(ilGenerator);
			methodScopeWeaver.Weave(ilGenerator);
			ilGenerator.Emit(OpCodes.Ret);
		}
	}
}
