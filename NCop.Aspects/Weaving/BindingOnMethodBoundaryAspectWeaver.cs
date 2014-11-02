using System;
using NCop.Aspects.Aspects;
using NCop.Core.Extensions;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingOnMethodBoundaryAspectWeaver : AbstractOnMethodBoundaryAspectWeaver
    {
        protected IArgumentsWeaver argumentsWeaver = null;

        internal BindingOnMethodBoundaryAspectWeaver(Type topAspectInScopeArgType, IAspectWeaver nestedWeaver, IAspectDefinition aspectDefinition, IAspectMethodWeavingSettings settings)
            : base(nestedWeaver, aspectDefinition, settings) {
            var @params = weavingSettings.MethodInfoImpl.GetParameters();

            argumentsWeavingSetings.Parameters = @params.ToArray(@param => @param.ParameterType);
            argumentsWeaver = new BindingOnMethodExecutionArgumentsWeaver(topAspectInScopeArgType, argumentsWeavingSetings, settings);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);

            return weaver.Weave(ilGenerator);
        }
    }
}
