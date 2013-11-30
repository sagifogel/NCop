using NCop.Aspects.Aspects;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Core.Extensions;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class AspectsAttributeWeaver : IWeaver, IAspectRepository
    {
        private readonly Dictionary<Type, Type> aspects = null;
        private readonly IAspectDefinitionCollection aspectDefinitions = null;

        public AspectsAttributeWeaver(IAspectDefinitionCollection aspectDefinitions) {
            this.aspectDefinitions = aspectDefinitions;
        }

        public Type GetByType(Type type) {
            return aspects[type];
        }

        internal void Weave() {
            var tuples = new List<Tuple<Type, FieldBuilder>>();
            var attrs = TypeAttributes.Sealed | TypeAttributes.Abstract | TypeAttributes.BeforeFieldInit;
            var uniqueAspects = aspectDefinitions.Select(definition => definition).Distinct();
            var typeBuilder = typeof(object).DefineType("Aspects".ToUniqueName(), attributes: attrs);
            var fieldAttrs = FieldAttributes.FamANDAssem | FieldAttributes.Static;

            uniqueAspects.ForEach((aspect, i) => {
                var aspectType = aspect.Aspect.AspectType;
                var fieldBuilder = typeBuilder.DefineField("Aspect_{0}".Fmt(i).ToUniqueName(), aspectType, fieldAttrs);

                tuples.Add(Tuple.Create(aspectType, fieldBuilder));
            });
        }
    }
}
