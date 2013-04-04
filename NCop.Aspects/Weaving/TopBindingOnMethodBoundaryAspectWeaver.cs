using NCop.Aspects.Aspects;
using NCop.Core.Extensions;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopBindingOnMethodBoundaryAspectWeaver : AbstractOnMethodBoundaryAspectWeaver
    {
        protected IArgumentsWeaver argumentsWeaver = null;

        internal TopBindingOnMethodBoundaryAspectWeaver(IAspectWeaver nestedWeaver, IAspectDefinition aspectDefinition, IAspectWeavingSettings settings)
            : base(nestedWeaver, aspectDefinition, settings) {
            var @params = weavingSettings.MethodInfoImpl.GetParameters();

            argumentsWeavingSetings.Parameters = @params.ToArray(@param => @param.ParameterType);
            argumentsWeaver = new TopBindingOnMethodExecutionArgumentsWeaver(argumentsWeavingSetings, settings);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);

            return weaver.Weave(ilGenerator);
        }
    }
}
