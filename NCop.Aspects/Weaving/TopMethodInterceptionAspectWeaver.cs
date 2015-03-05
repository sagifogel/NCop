using NCop.Aspects.Aspects;
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

        internal TopMethodInterceptionAspectWeaver(IMethodAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            IMethodScopeWeaver getReturnValueWeaver = null;
            var @params = aspectDefinition.Method.GetParameters();
            var byRefArgumentsStoreWeaver = aspectWeavingSettings.ByRefArgumentsStoreWeaver;

            if (argumentsWeavingSettings.IsFunction) {
                getReturnValueWeaver = new TopGetReturnValueWeaver(aspectWeavingSettings, argumentsWeavingSettings);
            }

            argumentsWeavingSettings.Parameters = @params.ToArray(@param => @param.ParameterType);
            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeaver = new TopMethodInterceptionArgumentsWeaver(aspectDefinition.Method, argumentsWeavingSettings, aspectWeavingSettings);

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

        public override void Weave(ILGenerator ilGenerator) {
            LocalBuilder bindingLocalBuilder = null;
            var bindingsReflectedType = bindingDependency.ReflectedType;

            bindingLocalBuilder = ilGenerator.DeclareLocal(bindingsReflectedType);
            localBuilderRepository.Add(bindingLocalBuilder);
            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);
        }
    }
}
