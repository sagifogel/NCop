using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using NCop.Composite.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopGetPropertyInterceptionAspectWeaver : AbstractInterceptionAspectWeaver
    {
        protected readonly IArgumentsWeaver argumentsWeaver = null;

        internal TopGetPropertyInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectMethodWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeavingSettings.Parameters = new[] { weavingSettings.MethodInfoImpl.ReturnType };
            argumentsWeaver = new TopGetPropertyInterceptionArgumentsWeaver(argumentsWeavingSettings, aspectWeavingSettings);
            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }

        protected override IAdviceExpression ResolveInterceptionAdviceExpression() {
            IAdviceDefinition selectedAdviceDefinition = null;
            var onGetPropertyAdvice = adviceDiscoveryVistor.OnGetPropertyAdvice;
            Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;

            adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnGetPropertyAdvice);
            selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onGetPropertyAdvice));

            return adviceExpressionFactory(selectedAdviceDefinition);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            //LocalBuilder argsLocalBuilder = null;
            //var aspectArgsType = weavingSettings.MethodInfoImpl.ToPropertyAspectArgument();

            //argumentsWeaver.Weave(ilGenerator);
            //weaver.Weave(ilGenerator);
            //argsLocalBuilder = localBuilderRepository.Get(argumentsWeavingSettings.ArgumentType);
            //ilGenerator.EmitLoadLocal(argsLocalBuilder);
            //ilGenerator.Emit(OpCodes.Callvirt, aspectArgsType.GetProperty("Value").GetGetMethod());
            var arguments = aspectDefinition.ToArgumentsWeavingSettings();
            var aspectMember = aspectRepository.GetAspectFieldByType(arguments.AspectType);
            var adviceMethod = aspectMember.FieldType.GetMethod("OnGetValue");
            var contractFieldBuilder = weavingSettings.TypeDefinition.GetFieldBuilder(weavingSettings.ContractType);
            
            ilGenerator.Emit(OpCodes.Ldsfld, contractFieldBuilder);
            ilGenerator.Emit(OpCodes.Ldnull);
            ilGenerator.Emit(OpCodes.Ldstr, "");
            ilGenerator.Emit(OpCodes.Callvirt, adviceMethod);

            return ilGenerator;
        }
    }
}
