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
		private readonly ILocalBuilderRepository localBuilderRepository = null;

		internal OnMethodInterceptionBindingWeaver(Type aspectType, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IAspectWeaver methodScopeWeaver)
			: base(bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
			
			localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
		}

		protected override void WeaveInvokeMethod() {
			ILGenerator ilGenerator = null;
			MethodBuilder methodBuilder = null;
			var methodParameters = ResolveParameterTypes();

			methodBuilder = typeBuilder.DefineMethod("Invoke", methodAttr, callingConventions, methodParameters.ReturnType, methodParameters.Parameters);
			ilGenerator = methodBuilder.GetILGenerator();
			localBuilderRepository.Add(ilGenerator.DeclareLocal(bindingSettings.BindingsDependency.FieldType));
			methodScopeWeaver.Weave(ilGenerator);
			ilGenerator.Emit(OpCodes.Ret);
		}
	}
}
