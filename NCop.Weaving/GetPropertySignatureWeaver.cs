using System.Reflection;
using System.Reflection.Emit;

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
