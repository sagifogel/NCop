
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public interface IEventTypeBuilder
    {
        void SetAddMethod(MethodBuilder addMethod);
        void SetRemoveMethod(MethodBuilder removeMethod);
    }
}
