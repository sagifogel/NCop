using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Exceptions;
using NCop.Aspects.Framework;
using NCop.Aspects.Properties;
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
            var typeAttrs = TypeAttributes.Sealed | TypeAttributes.Abstract;
            var typeBuilder = typeof(object).DefineType("Aspects".ToUniqueName(), attributes: typeAttrs);
            var fieldAttrs = FieldAttributes.Private | FieldAttributes.FamANDAssem | FieldAttributes.Static;
            var uniqueAspects = aspectDefinitions.Select(definition => definition.Aspect.AspectType).Distinct();
            var cctorAttrs = MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;
            var cctor = typeBuilder.DefineConstructor(cctorAttrs, CallingConventions.Standard, Type.EmptyTypes).GetILGenerator();

            uniqueAspects.ForEach((aspect, i) => {
                var fieldBuilder = typeBuilder.DefineField("Aspect_{0}".Fmt(i).ToUniqueName(), aspect, fieldAttrs);
                var ctor = fieldBuilder.FieldType.GetConstructor(Type.EmptyTypes);

                if (ctor.IsNull()) {
                    throw new AspectWeavingException(Resources.AspectsDefaultCtorHasNotBeenFound.Fmt(fieldBuilder.FieldType.FullName));
                }

                cctor.Emit(OpCodes.Newobj, ctor);
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
