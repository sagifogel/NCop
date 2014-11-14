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
        public AspectMethodWeaver(IAspectDefinitionCollection aspectDefinitions, IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            var aspectExpression = new AspectExpressionTreeBuilder(aspectDefinitions).Build();

            MethodEndWeaver = new MethodEndWeaver();
            MethodScopeWeaver = aspectExpression.Reduce(aspectWeavingSettings);
            MethodDefintionWeaver = new MethodSignatureWeaver(TypeDefinition);
        }
    }
}
