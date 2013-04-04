using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class MethodInvokerByRefArgumentsWeaver : AbstractByRefArgumentsStoreWeaver, ICanEmitLocalBuilderByRefArgumentsWeaver 
    {
        private LocalBuilder argsLocalBuilder;
        private readonly Type topAspectInScopeArgType = null;
        protected readonly IDictionary<int, LocalBuilder> byRefParamslocalBuilderMap = null;

        internal MethodInvokerByRefArgumentsWeaver(Type topAspectInScopeArgType, MethodInfo methodInfoImpl, ILocalBuilderRepository localBuilderRepository)
            : base(methodInfoImpl, localBuilderRepository) {
            this.topAspectInScopeArgType = topAspectInScopeArgType;
            byRefParamslocalBuilderMap = new Dictionary<int, LocalBuilder>();
        }

        public override bool Contains(int argPosition) {
            return byRefParamslocalBuilderMap.ContainsKey(argPosition);
        }

        public override void StoreArgsIfNeeded(ILGenerator ilGenerator) {
            argsLocalBuilder = localBuilderRepository.Get(topAspectInScopeArgType);

            parameters.ForEach(param => {
                LocalBuilder localBuilder;
                int argPosition = param.Position + 1;
                Type parameterElementType = param.ParameterType.GetElementType();
                var property = topAspectInScopeArgType.GetProperty("Arg{0}".Fmt(argPosition));

                if (!byRefParamslocalBuilderMap.TryGetValue(argPosition, out localBuilder)) {
                    localBuilder = ilGenerator.DeclareLocal(parameterElementType);
                    byRefParamslocalBuilderMap.Add(argPosition, localBuilder);
                }

                ilGenerator.EmitLoadLocal(argsLocalBuilder);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
                ilGenerator.EmitStoreLocal(localBuilder);
            });
        }

        public override void RestoreArgsIfNeeded(ILGenerator ilGenerator) {
            byRefParamslocalBuilderMap.ForEach(keyValue => {
                var argPosition = keyValue.Key;
                var localBuilder = keyValue.Value;
                var property = topAspectInScopeArgType.GetProperty("Arg{0}".Fmt(argPosition));

                ilGenerator.EmitLoadLocal(argsLocalBuilder);
                ilGenerator.EmitLoadLocal(localBuilder);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetSetMethod());
            });
        }

        public void EmitLoadLocalAddress(ILGenerator ilGenerator, int argPosition) {
            LocalBuilder localBuilder;

            if (byRefParamslocalBuilderMap.TryGetValue(argPosition, out localBuilder)) {
                ilGenerator.EmitLoadLocalAddress(localBuilder);
            }
        }
    }
}