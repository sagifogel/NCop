using NCop.Aspects.Aspects;
using NCop.Core.Extensions;
using System;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingOnMethodBoundaryAspectWeaver : AbstractOnMethodBoundaryAspectWeaver
    {
        protected IArgumentsWeaver argumentsWeaver = null;

        internal BindingOnMethodBoundaryAspectWeaver(Type topAspectInScopeArgType, IAspectWeaver nestedWeaver, IMethodAspectDefinition aspectDefinition, IAspectWeavingSettings settings)
            : base(nestedWeaver, aspectDefinition, settings) {
            var @params = aspectDefinition.Member.GetParameters();

            argumentsWeavingSettings.Parameters = @params.ToArray(@param => @param.ParameterType);
            argumentsWeaver = new BindingOnMethodExecutionArgumentsWeaver(aspectDefinition.Member, topAspectInScopeArgType, argumentsWeavingSettings, settings);
        }

        public override void Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);
        }
    }
}
