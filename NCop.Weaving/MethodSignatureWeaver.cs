using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class MethodSignatureWeaver : AbstractMemberSignatureWeaver
    {
        public MethodSignatureWeaver(ITypeDefinition typeDefinition)
            : base(typeDefinition) {
        }

        public override MethodBuilder Weave(MethodInfo method) {
            return typeDefinition.TypeBuilder.DefineMethod(method);
        }
    }
}
