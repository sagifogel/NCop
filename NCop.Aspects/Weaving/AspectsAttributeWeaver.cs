using NCop.Aspects.Aspects;
using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class AspectsAttributeWeaver : IWeaver, IAspectRepository
    {
        private Dictionary<Type, FieldInfo> aspects = null;
        private readonly IAspectDefinitionCollection aspectDefinitions = null;

        public AspectsAttributeWeaver(IAspectDefinitionCollection aspectDefinitions) {
            this.aspectDefinitions = aspectDefinitions;
        }

        public FieldInfo GetAspectFieldByType(Type type) {
            return aspects[type];
        }

        internal void Weave() {
            Type aspectAttributes = null;
            var fieldBuilders = new List<FieldBuilder>();
            var attrs = TypeAttributes.Sealed | TypeAttributes.Abstract | TypeAttributes.BeforeFieldInit;
            var uniqueAspects = aspectDefinitions.Select(definition => definition).Distinct();
            var typeBuilder = typeof(object).DefineType("Aspects".ToUniqueName(), attributes: attrs);
            var fieldAttrs = FieldAttributes.FamANDAssem | FieldAttributes.Static;
            var cctorAttrs = MethodAttributes.Private | MethodAttributes.Static| MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;
            var cctor = typeBuilder.DefineConstructor(cctorAttrs, CallingConventions.Standard, Type.EmptyTypes).GetILGenerator();

            uniqueAspects.ForEach((aspect, i) => {
                var aspectType = aspect.Aspect.AspectType;
                var fieldBuilder = typeBuilder.DefineField("Aspect_{0}".Fmt(i).ToUniqueName(), aspectType, fieldAttrs);

                cctor.Emit(OpCodes.Newobj, fieldBuilder.FieldType);
                cctor.Emit(OpCodes.Stsfld, fieldBuilder);
                fieldBuilders.Add(fieldBuilder);
            });

            cctor.Emit(OpCodes.Ret);
            aspectAttributes = typeBuilder.CreateType();

            aspects = fieldBuilders.ToDictionary(builder => builder.FieldType, builder => {
                return aspectAttributes.GetField(builder.Name, BindingFlags.Static | BindingFlags.NonPublic);
            });
        }
    }
}
