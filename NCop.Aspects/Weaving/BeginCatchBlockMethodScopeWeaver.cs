using NCop.Aspects.Framework;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
	internal class BeginCatchBlockMethodScopeWeaver : IMethodScopeWeaver
	{
		private readonly Type aspectArgumentType = null;
        private readonly IEnumerable<IMethodScopeWeaver> catchWeavers = null;
		private readonly ILocalBuilderRepository localBuilderRepository = null;

		internal BeginCatchBlockMethodScopeWeaver(IEnumerable<IMethodScopeWeaver> catchWeavers,  TryCatchFinallySettings tryCatchFinallySettings) {
            this.catchWeavers = catchWeavers;
			aspectArgumentType = tryCatchFinallySettings.AspectArgumentType;
			localBuilderRepository = tryCatchFinallySettings.LocalBuilderRepository;
		}

		public void Weave(ILGenerator ilGenerator) {
			var typeofException = typeof(Exception);
			LocalBuilder exceptionLocalBuilder = null;
			var typeofFlowBehavior = typeof(FlowBehavior);
			LocalBuilder flowBehavoiurLocalBuilder = null;
			var afterRethrowLabel = ilGenerator.DefineLabel();
			var throwFlowBehaviorLabel = ilGenerator.DefineLabel();
			var rethrowFlowBehaviorLabel = ilGenerator.DefineLabel();
			var argsImplLocalBuilder = localBuilderRepository.Get(aspectArgumentType);
			var jumpTable = new[] { throwFlowBehaviorLabel, rethrowFlowBehaviorLabel };
			var setExceptionMethodInfo = aspectArgumentType.GetProperty("Exception").GetSetMethod();
			var flowBehaviorMethodInfo = aspectArgumentType.GetProperty("FlowBehavior").GetGetMethod();
			
			exceptionLocalBuilder = localBuilderRepository.GetOrDeclare(typeofException, () => {
				return ilGenerator.DeclareLocal(typeofException);
			});

			flowBehavoiurLocalBuilder = localBuilderRepository.GetOrDeclare(typeofFlowBehavior, () => {
				return ilGenerator.DeclareLocal(typeofFlowBehavior);
			});

			ilGenerator.BeginCatchBlock(typeofException);
			ilGenerator.EmitStoreLocal(exceptionLocalBuilder);
			ilGenerator.EmitLoadLocal(argsImplLocalBuilder);
			ilGenerator.EmitLoadLocal(exceptionLocalBuilder);
			ilGenerator.Emit(OpCodes.Callvirt, setExceptionMethodInfo);

            catchWeavers.ForEach(weaver => weaver.Weave(ilGenerator));

            ilGenerator.EmitLoadLocal(argsImplLocalBuilder);
			ilGenerator.Emit(OpCodes.Callvirt, flowBehaviorMethodInfo);
			ilGenerator.EmitStoreLocal(flowBehavoiurLocalBuilder); 
			ilGenerator.EmitLoadLocal(flowBehavoiurLocalBuilder); 
			ilGenerator.EmitPushInteger(1);
			ilGenerator.Emit(OpCodes.Sub);
			ilGenerator.Emit(OpCodes.Switch, jumpTable);
			ilGenerator.Emit(OpCodes.Br_S, afterRethrowLabel);
			ilGenerator.MarkLabel(throwFlowBehaviorLabel);
			ilGenerator.EmitLoadLocal(exceptionLocalBuilder);
			ilGenerator.Emit(OpCodes.Throw);
			ilGenerator.MarkLabel(rethrowFlowBehaviorLabel);
			ilGenerator.Emit(OpCodes.Rethrow);
			ilGenerator.MarkLabel(afterRethrowLabel);
		}
	}
}
