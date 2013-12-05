using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class PropertyGetSignatureWeaver : AbstractMemberSignatureWeaver
    {
		public PropertyGetSignatureWeaver(ITypeDefinition typeDefinition)
			: base(typeDefinition) {
		}

        public override MethodBuilder Weave(MethodInfo methodInfo) {
            return typeDefinition.TypeBuilder.DefineParameterlessMethod(methodInfo);
        }
    }
}
