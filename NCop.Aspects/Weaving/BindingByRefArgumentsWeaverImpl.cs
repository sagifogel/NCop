using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingByRefArgumentsWeaverImpl : AbstractBindingByRefArgumentsWeaver
    {
        private LocalBuilder argsLocalBuilder;

        internal BindingByRefArgumentsWeaverImpl(Type topAspectInScopeArgType, MethodInfo method, ILocalBuilderRepository localBuilderRepository)
            : base(topAspectInScopeArgType, method, localBuilderRepository) {            
        }

        public override bool Contains(int argPosition) {
            return byRefParamslocalBuilderMap.ContainsKey(argPosition);
        }

        public override void StoreArgsIfNeeded(ILGenerator ilGenerator) {
            argsLocalBuilder = localBuilderRepository.Get(aspectArgumentType);

            base.StoreArgsIfNeeded(ilGenerator);
        }

        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            ilGenerator.EmitLoadLocal(argsLocalBuilder);
        }
    }
}