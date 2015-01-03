using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class GetPropertyDecoratorWeaver : AbstractMethodWeaver, IGetPropertyWeaver
    {
        public GetPropertyDecoratorWeaver(MethodInfo methodInfo, IWeavingSettings weavingSettings)
            : base(methodInfo, weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
            MethodScopeWeaver = new GetPropertyDecoratorScopeWeaver(methodInfo, weavingSettings);
			MethodDefintionWeaver = new GetPropertySignatureWeaver(weavingSettings.TypeDefinition);
		}
    }
}
