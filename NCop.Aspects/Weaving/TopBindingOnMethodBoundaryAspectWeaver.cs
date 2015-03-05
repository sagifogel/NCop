using NCop.Aspects.Aspects;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopBindingOnMethodBoundaryAspectWeaver : AbstractOnMethodBoundaryAspectWeaver
    {
        protected IArgumentsWeaver argumentsWeaver = null;

        internal TopBindingOnMethodBoundaryAspectWeaver(IAspectWeaver nestedWeaver, IMethodAspectDefinition aspectDefinition, IAspectWeavingSettings settings)
            : base(nestedWeaver, aspectDefinition, settings) {
            var @params = aspectDefinition.Method.GetParameters();

            argumentsWeavingSettings.Parameters = @params.ToArray(@param => @param.ParameterType);
            argumentsWeaver = new TopBindingOnMethodExecutionArgumentsWeaver(aspectDefinition.Method, argumentsWeavingSettings, settings);
        }

        protected override void AddEntryScopeWeavers(List<IMethodScopeWeaver> entryWeavers) {
            if (byRefArgumentsStoreWeaver.ContainsByRefParams) {
                Action<ILGenerator> storeArgsAction = byRefArgumentsStoreWeaver.StoreArgsIfNeeded;
                var storeArgsArgsWeaver = storeArgsAction.ToMethodScopeWeaver();

                entryWeavers.Add(storeArgsArgsWeaver);
            }
        }

        protected override void AddFinallyScopeWeavers(List<IMethodScopeWeaver> finallyWeavers) {
            finallyWeavers.Add(new TopAspectArgsMappingWeaverImpl(aspectWeavingSettings, argumentsWeavingSettings));
        }

        public override void Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);
        }
    }
}
