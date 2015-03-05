using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public abstract class AbstractMemberSignatureWeaver : IMethodSignatureWeaver
    {
        protected readonly ITypeDefinition typeDefinition = null;

        protected AbstractMemberSignatureWeaver(ITypeDefinition typeDefinition) {
            this.typeDefinition = typeDefinition;
        }

        public abstract MethodBuilder Weave(MethodInfo methodInfo);
    }
}