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

        public AspectArgsLocalWeaver(Type argsType) {
            ArgsType = argsType;
        }

        public Type ArgsType { get; private set; }

        public LocalBuilder Weave(ILGenerator ilGenerator) {
            return weaver ?? (weaver = ilGenerator.DeclareLocal(ArgsType));
        }
    }
}
