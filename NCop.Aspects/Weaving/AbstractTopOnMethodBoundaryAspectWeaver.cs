using NCop.Aspects.Aspects;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractTopOnMethodBoundaryAspectWeaver : AbstractOnMethodBoundaryAspectWeaver
    {
        internal AbstractTopOnMethodBoundaryAspectWeaver(IAspectWeaver nestedAspect, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(nestedAspect, aspectDefinition, aspectWeavingSettings) {
        }

        protected override void AddFinallyScopeWeavers(List<IMethodScopeWeaver> finallyWeavers) {
            if (byRefArgumentsStoreWeaver.ContainsByRefParams) {
                Action<ILGenerator> storeArgsAction = byRefArgumentsStoreWeaver.StoreArgsIfNeeded;
                var storeArgsArgsWeaver = storeArgsAction.ToMethodScopeWeaver();
                
                finallyWeavers.Add(storeArgsArgsWeaver);
            }
        }
    }
}
