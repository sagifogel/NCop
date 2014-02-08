using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class ByRefArgumentsStoreWeaverImpl : IByRefArgumentsStoreWeaver
    {
        private LocalBuilder argsLocalBuilder;
        private readonly ParameterInfo[] parameters = null;
        private readonly Type previousAspectArgType = null;
        private readonly ISet<int> byRefParamslocalBuilderMap = null;
        private readonly ILocalBuilderRepository localBuilderRepository = null;

        internal ByRefArgumentsStoreWeaverImpl(Type previousAspectArgType, MethodInfo methodInfoImpl, ILocalBuilderRepository localBuilderRepository) {
            byRefParamslocalBuilderMap = new HashSet<int>();
            this.previousAspectArgType = previousAspectArgType;
            this.localBuilderRepository = localBuilderRepository;
            parameters = methodInfoImpl.GetParameters().ToArray(param => param.ParameterType.IsByRef);
        }

        public bool ContainsByRefParams {
            get {
                return parameters.Length > 0;
            }
        }

        public void StoreLocalsIfNeeded(ILGenerator ilGenerator) {
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
        
        public void RestoreLocalsIfNeeded(ILGenerator ilGenerator) {
            byRefParamslocalBuilderMap.ForEach(argPosition => {
                var property = previousAspectArgType.GetProperty("Arg{0}".Fmt(argPosition));

                ilGenerator.EmitLoadLocal(argsLocalBuilder);
                ilGenerator.EmitLoadArg(argPosition);
                ilGenerator.Emit(OpCodes.Ldind_I4);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetSetMethod());
            });
        }

        public bool Contains(int argPosition) {
            return byRefParamslocalBuilderMap.Contains(argPosition);
        }
    }
}
