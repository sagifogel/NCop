using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class AspectArgsPropertyWeaver : IArgumentsWeaver
    {
        private readonly LocalBuilder methodLocalBuilder = null;
        private readonly IAspectMethodWeavingSettings aspectWeavingSettings = null;

        internal AspectArgsPropertyWeaver(LocalBuilder methodLocalBuilder, IAspectMethodWeavingSettings aspectWeavingSettings) {
            this.methodLocalBuilder = methodLocalBuilder;
            this.aspectWeavingSettings = aspectWeavingSettings;
        }

        public void Weave(ILGenerator ilGenerator) {
            var typeofType = typeof(Type);
            var typeofObject = typeof(object);
            FieldBuilder contractFieldBuilder = null;
            var weavingSettings = aspectWeavingSettings.WeavingSettings;
            var getTypeFromHandleMethodInfo = typeofType.GetMethod("GetTypeFromHandle");

            contractFieldBuilder = weavingSettings.TypeDefinition.GetFieldBuilder(weavingSettings.ContractType);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, typeofObject.GetMethod("GetType"));
            ilGenerator.Emit(OpCodes.Ldstr, weavingSettings.MethodInfoImpl.Name);
            ilGenerator.Emit(OpCodes.Ldtoken, typeof(string));
            ilGenerator.Emit(OpCodes.Call, getTypeFromHandleMethodInfo);
            ilGenerator.Emit(OpCodes.Callvirt, typeofType.GetMethod("GetProperty", new[] { typeof(string), typeof(Type) }));
            ilGenerator.Emit(OpCodes.Callvirt, typeof(PropertyInfo).GetMethod("GetGetMethod", Type.EmptyTypes));
            ilGenerator.EmitStoreLocal(methodLocalBuilder);
        }
    }
}
