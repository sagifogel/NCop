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
		public AspectMethodWeaver(IAspectDefinitionCollection aspectDefinitions, IWeavingSettings weavingSettings)
			: base(weavingSettings) {
				var aspectExpression = new AspectExpressionTreeBuilder(aspectDefinitions, weavingSettings).Build();
           
            MethodDefintionWeaver = new MethodSignatureWeaver();
            MethodScopeWeaver = aspectExpression.Reduce(AspectWeaverSettings.Empty);
            MethodEndWeaver = new MethodEndWeaver();
        }
    }
}
