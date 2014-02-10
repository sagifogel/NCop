using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopAspectByRefArgumentsStoreWeaverImpl : AbstractByRefArgumentsStoreWeaver
    {
        private LocalBuilder argsLocalBuilder;
        private readonly Type previousAspectArgType = null;
        protected readonly ISet<int> byRefParamslocalBuilderMap = null;

        internal TopAspectByRefArgumentsStoreWeaverImpl(Type previousAspectArgType, MethodInfo methodInfoImpl, ILocalBuilderRepository localBuilderRepository)
            : base(methodInfoImpl, localBuilderRepository) {
            this.previousAspectArgType = previousAspectArgType;
        }

        public override bool Contains(int argPosition) {
            return byRefParamslocalBuilderMap.Contains(argPosition);
        }

        public override void StoreArgsIfNeeded(ILGenerator ilGenerator) {
            argsLocalBuilder = localBuilderRepository.Get(previousAspectArgType);

            parameters.ForEach(param => {
                int argPosition = param.Position + 1;
                var property = previousAspectArgType.GetProperty("Arg{0}".Fmt(argPosition));

                ilGenerator.EmitLoadArg(argPosition);
                byRefParamslocalBuilderMap.Add(argPosition);
                ilGenerator.EmitLoadLocal(argsLocalBuilder);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
                ilGenerator.Emit(OpCodes.Stind_I4);
            });
        }

        public override void RestoreArgsIfNeeded(ILGenerator ilGenerator) {
            byRefParamslocalBuilderMap.ForEach(argPosition => {
                var property = previousAspectArgType.GetProperty("Arg{0}".Fmt(argPosition));

                ilGenerator.EmitLoadLocal(argsLocalBuilder);
                ilGenerator.EmitLoadArg(argPosition);
                ilGenerator.Emit(OpCodes.Ldind_I4);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetSetMethod());
            });
        }
    }
}
