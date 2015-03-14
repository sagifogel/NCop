using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class GetPropertyMethodSignatureWeaver : AbstractPropertyMethodSingatureWeaver
    {
        public GetPropertyMethodSignatureWeaver(IPropertyTypeBuilder propertyBuilder, ITypeDefinition typeDefinition)
            : base(propertyBuilder, typeDefinition) {
        }

        public override MethodBuilder Weave(MethodInfo method) {
            var methodBuilder = typeDefinition.TypeBuilder.DefineMethod(method);

            propertyBuilder.SetGetMethod(methodBuilder);

            return methodBuilder;
        }
    }
}
