using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractPropertyAspectDefinition : AbstractAspectDefinition<PropertyInfo>
    {
        internal AbstractPropertyAspectDefinition(IAspect aspect, Type aspectDeclaringType, PropertyInfo method)
            : base(aspect, aspectDeclaringType, method) {
        }
    }
}
