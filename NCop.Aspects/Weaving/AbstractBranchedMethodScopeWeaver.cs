using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractBranchedMethodScopeWeaver : AbstractMethodScopeWeaver
    {
        internal AbstractBranchedMethodScopeWeaver(MethodInfo methodInfo, IWeavingSettings weavingSettings)
            : base(methodInfo, weavingSettings) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            var isFunction = Method.IsFunction();
            var weaveFunction = isFunction ? WeaveFunction : (Action<ILGenerator>)WeaveAction;

            weaveFunction(ilGenerator);
        }

        protected abstract void WeaveAction(ILGenerator ilGenerator);
        protected abstract void WeaveFunction(ILGenerator ilGenerator);
    }
}
