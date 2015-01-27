using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractPropertyAspectDefinition : AbstractAspectDefinition, IPropertyAspectDefinition
    {
        internal AbstractPropertyAspectDefinition(Type aspectDeclaringType, PropertyInfo property)
            : base(aspectDeclaringType) {
            Property = property;
        }

        public PropertyInfo Property { get; protected set; }
    }
}
