using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class MethodDecoratorWeaver : AbstractMethodWeaver
    {
		public MethodDecoratorWeaver(MethodInfo methodInfo, IWeavingSettings weavingSettings)
			: base(methodInfo, weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
            MethodScopeWeaver = new MethodDecoratorScopeWeaver(methodInfo, weavingSettings);
			MethodDefintionWeaver = new MethodSignatureWeaver(weavingSettings.TypeDefinition);
		}
    }
}
