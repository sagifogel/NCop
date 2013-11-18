using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public class AspectMethodWeaver : AbstractMethodWeaver
    {
        public AspectMethodWeaver(IEnumerable<IAspectDefinition> aspectDefinitions, MethodInfo methodInfoImpl, Type implementationType, Type contractType)
            : base(methodInfoImpl, implementationType, contractType) {
                var aspectBuilder = new AspectExpression(aspectDefinitions);

        }
    }
}
