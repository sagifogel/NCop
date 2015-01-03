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
        internal AbstractPropertyAspectDefinition(IAspect aspect, Type aspectDeclaringType, MethodInfo method, PropertyInfo propertyInfoContract)
            : base(aspect, aspectDeclaringType, method) {
            PropertyInfo = propertyInfoContract;
        }

        public PropertyInfo PropertyInfo { get; protected set; }
    }
}
