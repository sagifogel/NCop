using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Weaving
{
	public class MethodSignatureWeaver : AbstractMemberSignatureWeaver
	{
		public MethodSignatureWeaver(ITypeDefinition typeDefinition)
			: base(typeDefinition) {
		}

		public override MethodBuilder Weave(MethodInfo methodInfo) {
			return typeDefinition.TypeBuilder.DefineMethod(methodInfo);
		}
	}
}
