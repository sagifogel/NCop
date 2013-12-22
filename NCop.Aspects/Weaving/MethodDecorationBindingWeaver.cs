using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
	internal class MethodDecoratorBindingWeaver : AbstractMethodBindingWeaver, IWithFieldAspectWeaver
	{
		private readonly IArgumentsWeaver argumentsWeaver = null;
		private readonly MethodParameters methodParameters = null;

		internal MethodDecoratorBindingWeaver(BindingSettings bindingSettings, IAspectWeavingSettings settings, IMethodScopeWeaver methodScopeWeaver)
			: base(bindingSettings, settings, methodScopeWeaver) {
			methodParameters = ResolveParameterTypes();
			argumentsWeaver = new MethodDecoratorArgumentsWeaver(bindingSettings.ArgumentType, methodParameters.Parameters, settings);
		}

		public FieldInfo WeavedType { get; private set; }

		protected override void WeaveInvokeMethod() {
			ILGenerator ilGenerator = null;
			MethodBuilder methodBuilder = null;

			methodBuilder = typeBuilder.DefineMethod("Invoke", methodAttr, callingConventions, methodParameters.ReturnType, methodParameters.Parameters);
			ilGenerator = methodBuilder.GetILGenerator();
			argumentsWeaver.Weave(ilGenerator);
			methodScopeWeaver.Weave(ilGenerator);
			ilGenerator.Emit(OpCodes.Ret);
		}
	}
}
