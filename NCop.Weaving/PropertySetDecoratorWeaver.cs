using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class PropertySetDecoratorWeaver : AbstractMethodWeaver, IPropertySetWeaver
    {
		public PropertySetDecoratorWeaver(IWeavingSettings weavingSettings)
            : base(weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
			MethodScopeWeaver = new PropertySetDecoratorScopeWeaver(weavingSettings);
			MethodDefintionWeaver = new PropertySetSignatureWeaver(weavingSettings.TypeDefinition);
		}
    }
}
