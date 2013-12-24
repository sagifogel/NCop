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
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving
{
	internal class OnMethodInterceptionBindingWeaver : AbstractMethodBindingWeaver
	{
		private readonly IArgumentsWeaver argumentsWeaver = null;
		private readonly ILocalBuilderRepository localBuilderRepository = null;

		internal OnMethodInterceptionBindingWeaver(Type aspectType, BindingSettings bindingSettings, IAspectWeavingSettings settings, IAspectWeaver methodScopeWeaver)
			: base(bindingSettings, settings, methodScopeWeaver) {
			var argumentWeavingSetings = bindingSettings.ToArgumentsWeavingSettings(aspectType);

			localBuilderRepository = new LocalBuilderRepository();
			argumentsWeaver = new AspectArgumentsWeaver(argumentWeavingSetings, settings, localBuilderRepository);
		}

		protected override void WeaveInvokeMethod() {
			ILGenerator ilGenerator = null;
			MethodBuilder methodBuilder = null;
			var methodParameters = ResolveParameterTypes();

			methodBuilder = typeBuilder.DefineMethod("Invoke", methodAttr, callingConventions, methodParameters.ReturnType, methodParameters.Parameters);
			ilGenerator = methodBuilder.GetILGenerator();
			localBuilderRepository.Add(ilGenerator.DeclareLocal(bindingSettings.BindingsDependency.FieldType));
			argumentsWeaver.Weave(ilGenerator);
			methodScopeWeaver.Weave(ilGenerator);
			ilGenerator.Emit(OpCodes.Ret);
		}
	}
}
