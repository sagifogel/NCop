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
		private readonly IArgumentsWeaver argumentsWeaver = null;

		internal OnMethodInterceptionBindingWeaver(BindingSettings bindingSettings, IAspectWeavingSettings settings, IAspectWeaver methodScopeWeaver, IMethodBindingWeaver nestedMethodBindingWeaver)
			: base(bindingSettings, settings, methodScopeWeaver) {
			var localBuilderRepository = new LocalBuilderRepository();
			var weavingSettings = settings.WeavingSettings;

			argumentsWeaver = new AspectArgumentsWeaver(settings.ArgumentsWeavingSettings.ArgumentType, settings.ArgumentsWeavingSettings.Parameters, settings, localBuilderRepository);
		}

		protected override void WeaveInvokeMethod() {
			ILGenerator ilGenerator = null;
			MethodBuilder methodBuilder = null;
			var methodParameters = ResolveParameterTypes();

			methodBuilder = typeBuilder.DefineMethod("Invoke", methodAttr, callingConventions, methodParameters.ReturnType, methodParameters.Parameters);
			ilGenerator = methodBuilder.GetILGenerator();
			argumentsWeaver.Weave(ilGenerator);
			methodScopeWeaver.Weave(ilGenerator);
			ilGenerator.Emit(OpCodes.Ret);
		}
	}
}
