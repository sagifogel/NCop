using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using NCop.Composite.Weaving;
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
    internal class TopMethodInterceptionAspectWeaver : AbstractMethodInterceptionAspectWeaver
    {
		protected IArgumentsWeaver argumentsWeaver = null;

        internal TopMethodInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            var @params = weavingSettings.MethodInfoImpl.GetParameters();

            argumentsWeavingSetings.Parameters = @params.ToArray(@param => @param.ParameterType);
            argumentsWeavingSetings.BindingsDependency = weavedType;
            argumentsWeaver = new TopMethodInterceptionArgumentsWeaver(argumentsWeavingSetings, aspectWeavingSettings);

            if (argumentsWeavingSetings.IsFunction) {
                methodScopeWeavers.Add(new GetReturnValueWeaver(aspectWeavingSettings, argumentsWeavingSetings));
            }
            
            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
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
