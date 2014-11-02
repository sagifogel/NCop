using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class GetPropertySignatureWeaver : AbstractMemberSignatureWeaver
    {
		public GetPropertySignatureWeaver(ITypeDefinition typeDefinition)
			: base(typeDefinition) {
		}

        public override MethodBuilder Weave(MethodInfo methodInfo) {
            return typeDefinition.TypeBuilder.DefineParameterlessMethod(methodInfo);
        }
    }
}
