using System.Reflection.Emit;

namespace NCop.Weaving
{
    public interface IPropertyTypeBuilder
    {
        void SetGetMethod(MethodBuilder method);
        void SetSetMethod(MethodBuilder method);
    }
}
