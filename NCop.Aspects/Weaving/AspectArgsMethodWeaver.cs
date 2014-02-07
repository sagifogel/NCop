using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class AspectArgsMethodWeaver : IArgumentsWeaver
    {
        private readonly Type[] parameters = null;
        private readonly LocalBuilder methodLocalBuilder = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;

        internal AspectArgsMethodWeaver(LocalBuilder methodLocalBuilder, Type[] parameters, IAspectWeavingSettings aspectWeavingSettings) {
            this.parameters = parameters;
            this.methodLocalBuilder = methodLocalBuilder;
            this.aspectWeavingSettings = aspectWeavingSettings;
        }

        public void Weave(ILGenerator ilGenerator) {
            var typeofType = typeof(Type);
            var typeofObject = typeof(object);
            FieldBuilder contractFieldBuilder = null;
            LocalBuilder typesArrayLocalBuilder = null;
            LocalBuilder tempTypesArrayLocalBuilder = null;
            var typeofArrayOfTypes = typeofType.MakeArrayType();
            var weavingSettings = aspectWeavingSettings.WeavingSettings;
            var getTypeFromHandleMethodInfo = typeofType.GetMethod("GetTypeFromHandle");
            var localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;

            typesArrayLocalBuilder = localBuilderRepository.Declare(() => {
                return ilGenerator.DeclareLocal(typeofArrayOfTypes);
            });

            tempTypesArrayLocalBuilder = ilGenerator.DeclareLocal(typeofArrayOfTypes);
            ilGenerator.EmitPushInteger(parameters.Length);
            ilGenerator.Emit(OpCodes.Newarr, typeofType);
            ilGenerator.EmitStoreLocal(tempTypesArrayLocalBuilder);

            parameters.ForEach((parameter, i) => {
                var isByRef = parameter.IsByRef;

                if (isByRef) {
                    parameter = parameter.GetElementType();
                }

                ilGenerator.EmitLoadLocal(tempTypesArrayLocalBuilder);
                ilGenerator.EmitPushInteger(i);
                ilGenerator.Emit(OpCodes.Ldtoken, parameter);
                ilGenerator.Emit(OpCodes.Call, getTypeFromHandleMethodInfo);

                if (isByRef) {
                    ilGenerator.Emit(OpCodes.Callvirt, typeofType.GetMethod("MakeByRefType"));
                }

                ilGenerator.Emit(OpCodes.Stelem_Ref);
            });

            ilGenerator.EmitLoadLocal(tempTypesArrayLocalBuilder);
            ilGenerator.EmitStoreLocal(typesArrayLocalBuilder);
            ilGenerator.EmitLoadArg(0);
            contractFieldBuilder = weavingSettings.TypeDefinition.GetFieldBuilder(weavingSettings.ContractType);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, typeofObject.GetMethod("GetType"));
            ilGenerator.Emit(OpCodes.Ldstr, weavingSettings.MethodInfoImpl.Name);
            ilGenerator.EmitLoadLocal(typesArrayLocalBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, typeofType.GetMethod("GetMethod", new Type[] { typeof(string), typeof(Type[]) }));
            ilGenerator.EmitStoreLocal(methodLocalBuilder);
        }
    }
}
