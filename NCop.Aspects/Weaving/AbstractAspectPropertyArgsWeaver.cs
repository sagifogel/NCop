using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractAspectPropertyArgsWeaver : IArgumentsWeaver
    {
        protected readonly PropertyInfo property = null;
        private readonly LocalBuilder methodLocalBuilder = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;

        internal AbstractAspectPropertyArgsWeaver(PropertyInfo property, LocalBuilder propertyLocalBuilder, IAspectWeavingSettings aspectWeavingSettings) {
            this.property = property;
            this.propertyLocalBuilder = propertyLocalBuilder;
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
            ilGenerator.Emit(OpCodes.Ldstr, property.Name);
            ilGenerator.Emit(OpCodes.Ldtoken, property.PropertyType);
            ilGenerator.Emit(OpCodes.Call, getTypeFromHandleMethodInfo);
            ilGenerator.Emit(OpCodes.Callvirt, typeofType.GetMethod("GetProperty", new[] { typeof(string), typeof(Type) }));
            ilGenerator.EmitStoreLocal(propertyLocalBuilder);
        }

        public LocalBuilder propertyLocalBuilder { get; set; }
    }
}
