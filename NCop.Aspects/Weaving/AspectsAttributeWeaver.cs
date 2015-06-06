using NCop.Aspects.Exceptions;
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
    public class AspectsAttributeWeaver : ITypeWeaver, IAspectRepository
    {
        private Dictionary<Type, FieldInfo> aspects = null;
        private readonly IEnumerable<Type> aspectTypes = null;

        public AspectsAttributeWeaver(IEnumerable<Type> aspectTypes) {
            this.aspectTypes = aspectTypes;
            //Weave();
        }

        public FieldInfo GetAspectFieldByType(Type type) {
            return aspects[type];
        }

        public void Weave() {
            Type aspectAttributes = null;
            var fieldBuilders = new List<FieldBuilder>();
            var typeBuilder = typeof(object).DefineType("Aspects".ToUniqueName(), attributes: TypeAttributes.Sealed | TypeAttributes.Abstract);
            var cctor = typeBuilder.DefineConstructor(MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName, CallingConventions.Standard, Type.EmptyTypes).GetILGenerator();

            aspectTypes.ForEach((aspect, i) => {
                var fieldBuilder = typeBuilder.DefineField("Aspect_{0}".Fmt(i).ToUniqueName(), aspect, FieldAttributes.Private | FieldAttributes.FamANDAssem | FieldAttributes.Static);
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
