using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class SetPropertyMethodSignatureWeaver : AbstractPropertyMethodSingatureWeaver
    {
        public SetPropertyMethodSignatureWeaver(IPropertyTypeBuilder propertyBuilder, ITypeDefinition typeDefinition)
            : base(propertyBuilder, typeDefinition) {
        }

        public override MethodBuilder Weave(MethodInfo method) {
            var methodBuilder = typeDefinition.TypeBuilder.DefineMethod(method);

            propertyBuilder.SetSetMethod(methodBuilder);

            return methodBuilder;
        }
    }
}
