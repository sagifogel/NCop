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
        private readonly Type parameter = null;
        private readonly LocalBuilder methodLocalBuilder = null;
        private readonly IAspectMethodWeavingSettings aspectWeavingSettings = null;

        internal AspectArgsPropertyWeaver(LocalBuilder methodLocalBuilder, Type parameter, IAspectMethodWeavingSettings aspectWeavingSettings) {
            this.parameter = parameter;
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
            ilGenerator.Emit(OpCodes.Newarr, typeofType);
            ilGenerator.EmitStoreLocal(tempTypesArrayLocalBuilder);
            ilGenerator.EmitLoadLocal(tempTypesArrayLocalBuilder);
            ilGenerator.Emit(OpCodes.Ldtoken, parameter);
            ilGenerator.Emit(OpCodes.Call, getTypeFromHandleMethodInfo);
            ilGenerator.Emit(OpCodes.Stelem_Ref);
            ilGenerator.EmitLoadLocal(tempTypesArrayLocalBuilder);
            ilGenerator.EmitStoreLocal(typesArrayLocalBuilder);
            ilGenerator.EmitLoadArg(0);
            contractFieldBuilder = weavingSettings.TypeDefinition.GetFieldBuilder(weavingSettings.ContractType);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, typeofObject.GetMethod("GetType"));
            ilGenerator.Emit(OpCodes.Ldstr, weavingSettings.MethodInfoImpl.Name);
            ilGenerator.EmitLoadLocal(typesArrayLocalBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, typeofType.GetMethod("GetMethod", new[] { typeof(string), typeof(Type[]) }));
            ilGenerator.EmitStoreLocal(methodLocalBuilder);
        }
    }
}
