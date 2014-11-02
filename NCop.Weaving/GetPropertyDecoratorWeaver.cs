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
		public GetPropertyDecoratorWeaver(IMethodWeavingSettings weavingSettings)
			: base(weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
			MethodScopeWeaver = new GetPropertyDecoratorScopeWeaver(weavingSettings);
			MethodDefintionWeaver = new GetPropertySignatureWeaver(weavingSettings.TypeDefinition);
		}
    }
}
