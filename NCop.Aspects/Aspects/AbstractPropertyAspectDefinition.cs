using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractPropertyAspectDefinition : AbstractAspectDefinition<MethodInfo>, IPropertyAspectDefinition
    {
        internal AbstractPropertyAspectDefinition(IAspect aspect, Type aspectDeclaringType, MemberInfo method, PropertyInfo propertyInfoContract)
            : base(aspect, aspectDeclaringType, method) {
            PropertyInfoContract = propertyInfoContract;
        }

        public PropertyInfo PropertyInfoContract { get; protected set; }
    }
}
