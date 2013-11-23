using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public class AspectArgsLocalWeaver : IMethodLocalWeaver
    {
        private LocalBuilder weaver = null;
        private readonly Type onMethodBoundaryArgsType = null;

        public AspectArgsLocalWeaver(Type onMethodBoundaryArgsType) {
            this.onMethodBoundaryArgsType = onMethodBoundaryArgsType;
        }

        public LocalBuilder Weave(ILGenerator ilGenerator) {
            return weaver ?? (weaver = ilGenerator.DeclareLocal(onMethodBoundaryArgsType));
        }
    }
}
