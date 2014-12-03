using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractBranchedMethodScopeWeaver : AbstractMethodScopeWeaver
    {
        internal AbstractBranchedMethodScopeWeaver(IMethodWeavingSettings weavingSettings)
            : base(weavingSettings) {
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            var isFunction = MethodInfoImpl.IsFunction();
            var weaveFunction = isFunction ? WeaveFunction : (Func<ILGenerator, ILGenerator>)WeaveAction;

            return weaveFunction(ilGenerator);
        }

        protected abstract ILGenerator WeaveAction(ILGenerator ilGenerator);
        protected abstract ILGenerator WeaveFunction(ILGenerator ilGenerator);
    }
}
