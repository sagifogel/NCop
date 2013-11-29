using NCop.Aspects.Aspects;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class AspectsAttributeWeaver : IWeaver, IAspectRepository
    {
        private readonly IAspectDefinitionCollection aspectDefinitions = null;

        public AspectsAttributeWeaver(IAspectDefinitionCollection aspectDefinitions) {
            this.aspectDefinitions = aspectDefinitions;
        }

        public Type GetByType(Type type) {
            throw new NotImplementedException();
        }

        internal void Weave() {
            var attrs = TypeAttributes.Sealed | TypeAttributes.Abstract | TypeAttributes.BeforeFieldInit;
            var unqiueAspects = aspectDefinitions.Select(defintion => defintion.AspectType).Distinct();

            typeof(object).DefineType("Aspects".ToUniqueName(), attributes: attrs);
        }
    }
}
