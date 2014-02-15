using NCop.Aspects.Aspects;
using NCop.Composite.Weaving;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopMethodInterceptionAspectWeaver : AbstractMethodInterceptionAspectWeaver
    {
        protected IArgumentsWeaver argumentsWeaver = null;

        internal TopMethodInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            IMethodScopeWeaver getReturnValueWeaver = null;
            var @params = weavingSettings.MethodInfoImpl.GetParameters();
            var byRefArgumentsStoreWeaver = aspectWeavingSettings.ByRefArgumentsStoreWeaver;

            if (argumentsWeavingSetings.IsFunction) {
                getReturnValueWeaver = new TopGetReturnValueWeaver(aspectWeavingSettings, argumentsWeavingSetings);
            }

            argumentsWeavingSetings.Parameters = @params.ToArray(@param => @param.ParameterType);
            argumentsWeavingSetings.BindingsDependency = weavedType;
            argumentsWeaver = new TopMethodInterceptionArgumentsWeaver(argumentsWeavingSetings, aspectWeavingSettings);

            if (!byRefArgumentsStoreWeaver.ContainsByRefParams) {

                if (getReturnValueWeaver.IsNotNull()) {
                    methodScopeWeavers.Add(getReturnValueWeaver);
                }

                weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
            }
            else {
                Action<ILGenerator> storeArgsIfNeededAction = byRefArgumentsStoreWeaver.StoreArgsIfNeeded;
                var finallyWeavers = new[] { storeArgsIfNeededAction.ToMethodScopeWeaver() };

                weaver = new TryFinallyAspectWeaver(methodScopeWeavers, finallyWeavers, getReturnValueWeaver);
            }
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            LocalBuilder bindingLocalBuilder = null;
            var bindingsReflectedType = bindingDependency.ReflectedType;

            bindingLocalBuilder = ilGenerator.DeclareLocal(bindingsReflectedType);
            localBuilderRepository.Add(bindingLocalBuilder);
            argumentsWeaver.Weave(ilGenerator);

            return weaver.Weave(ilGenerator);
        }
    }
}
