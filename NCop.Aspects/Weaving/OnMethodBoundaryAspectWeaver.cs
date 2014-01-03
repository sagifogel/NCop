using NCop.Aspects.Aspects;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using NCop.Core.Extensions;
using NCop.Aspects.Weaving.Expressions;
using NCop.Aspects.Advices;
using NCop.Composite.Weaving;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving
{
    internal class OnMethodBoundaryAspectWeaver : AbstractOnMethodBoundaryAspectWeaver
	{
        protected IArgumentsWeaver argumentsWeaver = null;
        
        internal OnMethodBoundaryAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings settings)
			: base(aspectDefinition, settings) {
            var @params = weavingSettings.MethodInfoImpl.GetParameters();

            argumentsWeavingSetings.Parameters = @params.Select(@param => @param.ParameterType).ToArray();
            argumentsWeaver = new MethodInterceptionImplArgumentsWeaver(argumentsWeavingSetings, settings);
		}

		public override ILGenerator Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);

			return weaver.Weave(ilGenerator);
		}
	}
}
