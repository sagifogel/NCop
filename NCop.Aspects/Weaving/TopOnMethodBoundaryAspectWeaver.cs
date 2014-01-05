using NCop.Aspects.Aspects;
using NCop.Composite.Weaving;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NCop.Weaving.Extensions;
using NCop.Core.Extensions;

namespace NCop.Aspects.Weaving
{
    internal class TopOnMethodBoundaryAspectWeaver : AbstractOnMethodBoundaryAspectWeaver
    {
        protected IArgumentsWeaver argumentsWeaver = null;

        internal TopOnMethodBoundaryAspectWeaver(IAspectWeaver nestedWeaver, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(nestedWeaver, aspectDefinition, aspectWeavingSettings) {
            var @params = weavingSettings.MethodInfoImpl.GetParameters();

            methodScopeWeavers = new List<IMethodScopeWeaver>();
            argumentsWeavingSetings.Parameters = @params.ToArray(@param => @param.ParameterType).ToArray();
            argumentsWeaver = new OnMethodBoundaryImplArgumentsWeaver(argumentsWeavingSetings, aspectWeavingSettings);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);

            return weaver.Weave(ilGenerator);
        }
    }
}
