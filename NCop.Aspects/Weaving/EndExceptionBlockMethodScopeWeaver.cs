using NCop.Composite.Weaving;
using NCop.Core.Extensions;
using NCop.Weaving;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class EndExceptionBlockMethodScopeWeaver : IMethodScopeWeaver
    {
        private readonly Label endOfExceptionBlockLabel;

        internal EndExceptionBlockMethodScopeWeaver(Label endOfExceptionBlockLabel) {
            this.endOfExceptionBlockLabel = endOfExceptionBlockLabel;
        }

        public ILGenerator Weave(ILGenerator ilGenerator) {
            ilGenerator.EndExceptionBlock();
            ilGenerator.MarkLabel(endOfExceptionBlockLabel);

            return ilGenerator;
        }
    }
}