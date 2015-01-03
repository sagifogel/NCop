using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class SetPropertyDecoratorWeaver : AbstractMethodWeaver, ISetPropertyWeaver
    {
		public SetPropertyDecoratorWeaver(MethodInfo methodInfo, IWeavingSettings weavingSettings)
            : base(methodInfo, weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
            MethodScopeWeaver = new SetPropertyDecoratorScopeWeaver(methodInfo, weavingSettings);
			MethodDefintionWeaver = new SetPropertySignatureWeaver(weavingSettings.TypeDefinition);
		}
    }
}
