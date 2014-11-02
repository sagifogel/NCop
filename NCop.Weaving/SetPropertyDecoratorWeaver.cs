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
		public SetPropertyDecoratorWeaver(IMethodWeavingSettings weavingSettings)
            : base(weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
			MethodScopeWeaver = new SetPropertyDecoratorScopeWeaver(weavingSettings);
			MethodDefintionWeaver = new SetPropertySignatureWeaver(weavingSettings.TypeDefinition);
		}
    }
}
